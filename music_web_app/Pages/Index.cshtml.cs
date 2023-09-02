using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using music_app_model;
using Microsoft.EntityFrameworkCore;
using music_web_app.Data;

namespace music_web_app.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public readonly music_web_app_DBContext _context;
        public IndexModel(ILogger<IndexModel> logger, music_web_app_DBContext context)
        {
            _context = context;
            _logger = logger;
        }
        [BindProperty]
        public InputModel Input { get; set; }

        [BindProperty]
        public User User { get; set; }
        public string message;
        public IList<User> Users { get; set; }
        public IList<Song> Songs { get; set; }
        public class InputModel
        {
            [Required]
            public string UserName { get; set; } = default!;

            [Required]
            public string Email { get; set; } = default!;
            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; } = default!;

            [Required]
            [DataType(DataType.Password)]
            [Compare("Password")]
            public string Repassword { get; set; } = default!;
        }
        public async Task OnGetAsync()
        {
            var session_user = HttpContext.Session.GetInt32("UserId");

            Users = await _context.User.ToListAsync();
            if (session_user != null)
            {
                ViewData["Session"] = session_user;
                var result = from s in Users
                             where s.UserID == session_user
                             select s;

                ViewData["Avatar"] = result.FirstOrDefault().Avatar;
                ViewData["Username"] = result.FirstOrDefault().UserName;
            }
            Songs = await _context.Song.
                Include(s => s.Singer).ToListAsync();


            // User = await _context.User.SingleOrDefault(a => a.UserName.Equals(a1));
        }

        public IActionResult OnGetLogout()
        {
            HttpContext.Session.Remove("username");
            HttpContext.Session.Remove("UserId");
            HttpContext.Session.Remove("Admin");
            return RedirectToPage("Index");
        }
        public IActionResult OnPostLogin()
        {
            string user_UserName = User.UserName;
            string user_pass = User.Pass;
            var acclogin = checkLogin(user_UserName, user_pass);
            if (acclogin == null)
            {
                message = "Invalid Account";
                return Page();
            }
            else
            {
                HttpContext.Session.SetString("username", acclogin.UserName);
                HttpContext.Session.SetInt32("UserId", acclogin.UserID);
                HttpContext.Session.SetInt32("Admin", acclogin.IsAdmin);

                if ((HttpContext.Session.GetInt32("Admin")) == 1)
                {
                    return RedirectToPage("/Admin/Index");
                }
                else
                {
                    return RedirectToPage("Index");
                }
            }
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var User = new User();

            User.UserName = Input.UserName;
            User.Email = Input.Email;
            User.Pass = BCrypt.Net.BCrypt.HashPassword(Input.Password);
            User.Avatar = "https://res.cloudinary.com/dabdclkhv/image/upload/v1666955265/Avatar/avatar_tuunso.webp";
            User.Name = Input.UserName;
            User.IsAdmin = 0;

            _context.User.Add(User);
            await _context.SaveChangesAsync();
            return Page();
        }

        private User checkLogin(string username, string password)
        {
            var accounts = _context.User.SingleOrDefault(a => a.UserName.Equals(username));
            if (accounts != null)
            {
                if (accounts.Pass == "admin")
                {
                    return accounts;
                }
                if (BCrypt.Net.BCrypt.Verify(password, accounts.Pass))
                {
                    return accounts;
                }
                else
                {
                    return null;
                }
            }
            return null;
        }
    }
}