using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Agri_Energy_Connect_Application.Models;
using Agri_Enery_Connect.Areas.Identity.Data;

namespace Agri_Enery_Connect.Areas.Identity.Pages.FarmerCategories
{
    public class CreateModel : PageModel
    {
        private readonly Agri_Enery_Connect.Areas.Identity.Data.AgriEneryConnectContext _context;

        public CreateModel(Agri_Enery_Connect.Areas.Identity.Data.AgriEneryConnectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public FarmerCategory FarmerCategory { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.FarmerCategory == null || FarmerCategory == null)
            {
                return Page();
            }

            _context.FarmerCategory.Add(FarmerCategory);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
