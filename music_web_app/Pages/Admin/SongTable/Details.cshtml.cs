using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using music_app_model;
using music_web_app.Data;

namespace music_web_app.Pages.Admin.SongTable
{
    public class DetailsModel : PageModel
    {
        private readonly music_web_app.Data.music_web_app_DBContext _context;

        public DetailsModel(music_web_app.Data.music_web_app_DBContext context)
        {
            _context = context;
        }

        public Song Song { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Song = await _context.Song
                .Include(s => s.CategorySong)
                .Include(s => s.Singer).FirstOrDefaultAsync(m => m.IdSong == id);

            if (Song == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
