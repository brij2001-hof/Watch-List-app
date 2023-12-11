using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectMangukiyaBrijMukesh;

namespace ProjectMangukiyaBrijMukesh.Pages.tblwatch_list
{
    public class EditModel : PageModel
    {
        private readonly ProjectMangukiyaBrijMukesh.Bmangukiya1Context _context;

        public EditModel(ProjectMangukiyaBrijMukesh.Bmangukiya1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public TblWatchList TblWatchList { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblwatchlist =  await _context.TblWatchLists.FirstOrDefaultAsync(m => m.ListId == id);
            if (tblwatchlist == null)
            {
                return NotFound();
            }
            TblWatchList = tblwatchlist;
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

            _context.Attach(TblWatchList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblWatchListExists(TblWatchList.ListId))
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

        private bool TblWatchListExists(int id)
        {
            return _context.TblWatchLists.Any(e => e.ListId == id);
        }
    }
}
