using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Agri_Energy_Connect_Application.Models;
using Agri_Enery_Connect.Areas.Identity.Data;

namespace Agri_Enery_Connect.Pages.FarmerView
{
    public class DetailsModel : PageModel
    {
        private readonly Agri_Enery_Connect.Areas.Identity.Data.AgriEneryConnectContext _context;

        public DetailsModel(Agri_Enery_Connect.Areas.Identity.Data.AgriEneryConnectContext context)
        {
            _context = context;
        }

      public FarmerProduct FarmerProduct { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.FarmerProduct == null)
            {
                return NotFound();
            }

            var farmerproduct = await _context.FarmerProduct.FirstOrDefaultAsync(m => m.Id == id);
            if (farmerproduct == null)
            {
                return NotFound();
            }
            else 
            {
                FarmerProduct = farmerproduct;
            }
            return Page();
        }
    }
}
