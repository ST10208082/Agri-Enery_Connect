using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Agri_Energy_Connect_Application.Models;
using Agri_Enery_Connect.Areas.Identity.Data;

namespace Agri_Enery_Connect.Areas.Identity.Pages.FarmerCategories
{
    public class EditModel : PageModel
    {
        private readonly Agri_Enery_Connect.Areas.Identity.Data.AgriEneryConnectContext _context;

        public EditModel(Agri_Enery_Connect.Areas.Identity.Data.AgriEneryConnectContext context)
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

            var farmercategory =  await _context.FarmerCategory.FirstOrDefaultAsync(m => m.Id == id);
            if (farmercategory == null)
            {
                return NotFound();
            }
            FarmerCategory = farmercategory;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(FarmerCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FarmerCategoryExists(FarmerCategory.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FarmerCategoryExists(int id)
        {
          return (_context.FarmerCategory?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
