using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using music_app_model;
using music_web_app.Data;

namespace music_web_app.Pages.Admin.SongTable
{
    public class EditModel : PageModel
    {
        private readonly music_web_app.Data.music_web_app_DBContext _context;

        public EditModel(music_web_app.Data.music_web_app_DBContext context)
        {
            _context = context;
        }

        [BindProperty]
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
            ViewData["IdCategory"] = new SelectList(_context.CategorySong, "IdCategory", "NameCategory");
            ViewData["IdSinger"] = new SelectList(_context.Singer, "IDSinger", "NameSinger");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Song).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SongExists(Song.IdSong))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SongExists(int id)
        {
            return _context.Song.Any(e => e.IdSong == id);
        }
    }
}
