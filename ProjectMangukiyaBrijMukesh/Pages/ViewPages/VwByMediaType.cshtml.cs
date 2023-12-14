using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ProjectMangukiyaBrijMukesh.Pages.ViewPages
{
    public class VwByMediaTypeModel : PageModel
    {
        private readonly Bmangukiya1Context _context;
        public VwByMediaTypeModel(Bmangukiya1Context context)
        {
            _context = context;
        }
        public IList<VwByMediaType> VwByMediaType { get; set; } = default!;
        public void OnGet()
        {
            VwByMediaType = _context.VwByMediaTypes.ToList();
        }
    }
}
