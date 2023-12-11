using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectMangukiyaBrijMukesh;

namespace ProjectMangukiyaBrijMukesh.Pages.tblwatch_list
{
    public class CreateModel : PageModel
    {
        private readonly ProjectMangukiyaBrijMukesh.Bmangukiya1Context _context;

        public CreateModel(ProjectMangukiyaBrijMukesh.Bmangukiya1Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TblWatchList TblWatchList { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TblWatchLists.Add(TblWatchList);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
