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
    public class DetailsModel : PageModel
    {
        private readonly ProjectMangukiyaBrijMukesh.Bmangukiya1Context _context;

        public DetailsModel(ProjectMangukiyaBrijMukesh.Bmangukiya1Context context)
        {
            _context = context;
        }

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
    }
}
