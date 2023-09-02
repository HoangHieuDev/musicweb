using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using music_app_model;
using music_web_app.Data;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace music_web_app.Pages.Admin.SongTable
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
            ViewData["IdCategory"] = new SelectList(_context.CategorySong, "IdCategory", "NameCategory");
            ViewData["IdSinger"] = new SelectList(_context.Singer, "IDSinger", "NameSinger");
            return Page();
        }
        [Required(ErrorMessage = "Please choose one file!")]
        [DataType(DataType.Upload)]
        [Display(Name = "Choose file image to upload")]
        [BindProperty]
        public IFormFile file_image { get; set; } = default!;

        [Required(ErrorMessage = "Please choose one file!")]
        [DataType(DataType.Upload)]
        [Display(Name = "Choose file song to upload")]
        [BindProperty]
        public IFormFile file_song { get; set; } = default!;
        [BindProperty]
        public Song Song { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(IFormFile file_song, IFormFile file_image)
        {
            if (file_song == null || file_image == null)
            {
                ViewData["IdCategory"] = new SelectList(_context.CategorySong, "IdCategory", "NameCategory");
                ViewData["IdSinger"] = new SelectList(_context.Singer, "IDSinger", "Avatar");
                return Page();
            }

            //upload image song to sever
            var result_img = await Program.cloudinary.UploadAsync(new ImageUploadParams
            {
                File = new FileDescription(file_image.FileName,
                file_image.OpenReadStream()),
                Folder = "Image",
            }).ConfigureAwait(false);
            string URL_Img = result_img.Url.AbsoluteUri;

            //upload image song to sever
            var result_song = await Program.cloudinary.UploadAsync(new VideoUploadParams
            {
                File = new FileDescription(file_song.FileName,
                file_song.OpenReadStream()),
                Folder = "Music",
            }).ConfigureAwait(false);
            string URL_Song = result_song.Url.AbsoluteUri;

            Song.URL = URL_Song;
            Song.Listens = 0;
            Song.ImageSong = URL_Img;
            Song.DateUpload = DateTime.Now.ToLongDateString().ToString();
            _context.Song.Add(Song);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
