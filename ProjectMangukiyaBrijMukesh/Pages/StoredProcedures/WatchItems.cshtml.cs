using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ProjectMangukiyaBrijMukesh.Pages.StoredProcedures
{
    public class WatchItemsModel : PageModel
    {
        private readonly Bmangukiya1Context _context;
        public WatchItemsModel(Bmangukiya1Context context)
        {
            _context = context;
        }
        [BindProperty]
        public List<spByWatchList> spByWatchList { get; set; } = default!;
        public async Task OnGetAsync(int id)
        {
            var listid = new Microsoft.Data.SqlClient.SqlParameter("@listid", id);
            spByWatchList = await _context.spByWatchLists.FromSqlRaw("Exec spByWatchList @listid={0}", listid).ToListAsync();
            spByWatchList.Reverse();

        }
    }
}
