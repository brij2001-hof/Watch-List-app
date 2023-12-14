using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace ProjectMangukiyaBrijMukesh.Pages.ViewPages
{
    public class VwCountByDateModel : PageModel
    {
        private readonly Bmangukiya1Context _context;
        public VwCountByDateModel(Bmangukiya1Context context)
        {
            _context = context;
        }
        public IList<VwCountByDate> VwCountByDate { get; set; } = default!;
        public string? json { get; set; }
        public void OnGet()
        {
            VwCountByDate = _context.VwCountByDates.ToList();
            json = JsonConvert.SerializeObject(VwCountByDate);
            System.Diagnostics.Debug.WriteLine(json);
        }
    }
}
