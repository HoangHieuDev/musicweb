using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using music_app_model;
using music_web_app.Data;

namespace music_web_app.Pages.Admin.SingerTable
{
    public class DeleteModel : PageModel
    {
        private readonly music_web_app.Data.music_web_app_DBContext _context;

        public DeleteModel(music_web_app.Data.music_web_app_DBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Singer Singer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Singer = await _context.Singer.FirstOrDefaultAsync(m => m.IDSinger == id);

            if (Singer == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Singer = await _context.Singer.FindAsync(id);

            if (Singer != null)
            {
                _context.Singer.Remove(Singer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
