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

namespace music_web_app.Pages.Admin.SingerTable
{
    public class EditModel : PageModel
    {
        private readonly music_web_app.Data.music_web_app_DBContext _context;

        public EditModel(music_web_app.Data.music_web_app_DBContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Singer).State = EntityState.Modified;

            try
            {
                Singer.UpdDate = DateTime.Now.ToLongDateString().ToString();
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SingerExists(Singer.IDSinger))
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

        private bool SingerExists(int id)
        {
            return _context.Singer.Any(e => e.IDSinger == id);
        }
    }
}
