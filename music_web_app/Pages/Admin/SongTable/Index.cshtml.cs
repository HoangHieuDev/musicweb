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
    public class IndexModel : PageModel
    {
        private readonly music_web_app.Data.music_web_app_DBContext _context;

        public IndexModel(music_web_app.Data.music_web_app_DBContext context)
        {
            _context = context;
        }

        public IList<Song> Song { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Song = await _context.Song
                .Include(s => s.CategorySong)
                .Include(s => s.Singer).ToListAsync();
        }
    }
}
