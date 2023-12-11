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
    public class IndexModel : PageModel
    {
        private readonly ProjectMangukiyaBrijMukesh.Bmangukiya1Context _context;

        public IndexModel(ProjectMangukiyaBrijMukesh.Bmangukiya1Context context)
        {
            _context = context;
        }

        public IList<TblWatchList> TblWatchList { get;set; } = default!;

        public async Task OnGetAsync()
        {
            TblWatchList = await _context.TblWatchLists.ToListAsync();
        }
    }
}
