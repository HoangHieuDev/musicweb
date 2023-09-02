using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using music_app_model;
using music_web_app.Data;

namespace music_web_app.Pages.Admin.SingerTable
{
    public class CreateModel : PageModel
    {
        private readonly music_web_app.Data.music_web_app_DBContext _context;

        public CreateModel(music_web_app.Data.music_web_app_DBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [Required(ErrorMessage = "Please choose one file!")]
        [DataType(DataType.Upload)]
        [Display(Name = "Choose file avatar to upload")]
        [BindProperty]
        public IFormFile file_avatar { get; set; } = default!;

        [BindProperty]
        public Singer Singer { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(IFormFile file_avatar)
        {
            if (file_avatar == null)
            {
                return Page();
            }
            //upload avatar singer to sever
            var result_img = await Program.cloudinary
                .UploadAsync(
                    new ImageUploadParams
                    {
                        File = new FileDescription(
                            file_avatar.FileName,
                            file_avatar.OpenReadStream()
                        ),
                        Folder = "Avatar",
                    }
                ).ConfigureAwait(false);
            Singer.Gender = Request.Form["Gender"].ToString();
            string URL_Img = result_img.Url.AbsoluteUri;
            Singer.AddDate = DateTime.Now.ToLongDateString().ToString();
            Singer.Avatar = URL_Img;
            _context.Singer.Add(Singer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
