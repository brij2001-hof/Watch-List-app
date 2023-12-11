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
            ViewData["listid"] = id;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            string mediaid = Request.Form["mediaid"].ToString();
            string listid = Request.Form["listid"].ToString();
            //remove
            var mediaid1 = new Microsoft.Data.SqlClient.SqlParameter("@mediaid", mediaid);
            var listid1 = new Microsoft.Data.SqlClient.SqlParameter("@listid", listid);
            await _context.Database.ExecuteSqlRawAsync("Exec spDeleteMedia @mid={0} , @lid={1}", mediaid1, listid1);
            return Redirect($"/watchListDetails/?id={listid}");
        }
    }
}
