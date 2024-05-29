using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Agri_Energy_Connect_Application.Models;
using Agri_Enery_Connect.Areas.Identity.Data;

namespace Agri_Enery_Connect.Areas.Identity.Pages.FarmerProducts
{
    public class IndexModel : PageModel
    {
        private readonly Agri_Enery_Connect.Areas.Identity.Data.AgriEneryConnectContext _context;

        public IndexModel(Agri_Enery_Connect.Areas.Identity.Data.AgriEneryConnectContext context)
        {
            _context = context;
        }

        public IList<FarmerProduct> Products { get; set; }
        [BindProperty]
        public FarmerProduct NewProduct { get; set; }

        public void OnGet()
        {
            Products = _context.FarmerProduct.ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                _context.FarmerProduct.Add(NewProduct);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            return Page();
        }
        

        
    }
}
