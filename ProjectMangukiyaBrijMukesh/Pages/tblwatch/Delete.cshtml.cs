using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectMangukiyaBrijMukesh;

namespace ProjectMangukiyaBrijMukesh.Pages.tblwatch_list
{
    public class DeleteModel : PageModel
    {
        private readonly ProjectMangukiyaBrijMukesh.Bmangukiya1Context _context;

        public DeleteModel(ProjectMangukiyaBrijMukesh.Bmangukiya1Context context)
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

            var tblwatchlist = await _context.TblWatchLists.FirstOrDefaultAsync(m => m.ListId == id);

            if (tblwatchlist == null)
            {
                return NotFound();
            }
            else
            {
                TblWatchList = tblwatchlist;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblwatchlist = await _context.TblWatchLists.FindAsync(id);
            if (tblwatchlist != null)
            {
                TblWatchList = tblwatchlist;
                _context.TblWatchLists.Remove(TblWatchList);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
