using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Agri_Energy_Connect_Application.Models;
using Agri_Enery_Connect.Areas.Identity.Data;

namespace Agri_Enery_Connect.Areas.Identity.Pages.FarmerCategories
{
    public class DeleteModel : PageModel
    {
        private readonly Agri_Enery_Connect.Areas.Identity.Data.AgriEneryConnectContext _context;

        public DeleteModel(Agri_Enery_Connect.Areas.Identity.Data.AgriEneryConnectContext context)
        {
            _context = context;
        }

        [BindProperty]
      public FarmerCategory FarmerCategory { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.FarmerCategory == null)
            {
                return NotFound();
            }

            var farmercategory = await _context.FarmerCategory.FirstOrDefaultAsync(m => m.Id == id);

            if (farmercategory == null)
            {
                return NotFound();
            }
            else 
            {
                FarmerCategory = farmercategory;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.FarmerCategory == null)
            {
                return NotFound();
            }
            var farmercategory = await _context.FarmerCategory.FindAsync(id);

            if (farmercategory != null)
            {
                FarmerCategory = farmercategory;
                _context.FarmerCategory.Remove(FarmerCategory);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
