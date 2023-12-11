using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ProjectMangukiyaBrijMukesh.Pages.StoredProcedures
{
    public class spByGenreModel : PageModel
    {
        private readonly Bmangukiya1Context _context;
        public spByGenreModel(Bmangukiya1Context context)
        {
            _context = context;
        }
        [BindProperty]
        public List<spByGenre> spByGenres { get; set; } = default!;
        public SelectList genres { get; set; } = default!;
        public async Task OnGetAsync(string genre = null)
        {
            spByGenres = await _context.spByGenres.FromSqlRaw("Exec spByGenre @genre={0}", genre).ToListAsync();
            spByGenres.Reverse();
            genres = new SelectList(_context.TblGenres, "Name", "Name");
        }

        public async Task<IActionResult> OnPost()
        {
            string genre = Request.Form["selected"].ToString();
            return Redirect($"/spByGenre/?genre={genre}");
        }
    }


}
