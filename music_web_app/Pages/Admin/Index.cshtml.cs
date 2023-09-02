using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using music_app_model;

namespace music_web_app.Pages.Admin
{
    public class Index : PageModel
    {
        private readonly music_web_app.Data.music_web_app_DBContext _context;

        public Index(music_web_app.Data.music_web_app_DBContext context)
        {
            _context = context;
        }

        public IList<Singer> Singer { get; set; }
        public IList<Song> Song { get; set; }
        public IList<User> User { get; set; }

        public async Task OnGetAsync()
        {
            Song = await _context.Song.ToListAsync();
            ViewData["TotalSong"] = Song.Count();
            ViewData["TotalListen"] = Song.Sum(h => h.Listens);


            Singer = await _context.Singer.ToListAsync();
            ViewData["TotalSinger"] = Singer.Count();


            User = await _context.User.ToListAsync();
            ViewData["TotalUser"] = User.Count();
        }
    }
}
