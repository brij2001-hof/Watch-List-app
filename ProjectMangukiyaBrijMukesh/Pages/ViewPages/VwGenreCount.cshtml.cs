using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ProjectMangukiyaBrijMukesh.Pages.ViewPages
{
    public class VwGenreCountModel : PageModel
    {
        private readonly Bmangukiya1Context _context;
        public VwGenreCountModel(Bmangukiya1Context context)
        {
            _context = context;
        }
        public IList<VwGenreCount> VwGenreCount { get; set; } = default!;
        public void OnGet()
        {
            VwGenreCount = _context.VwGenreCounts.ToList();

        }
    }
}
