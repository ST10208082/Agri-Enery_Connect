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
    public class IndexModel : PageModel
    {
        private readonly Agri_Enery_Connect.Areas.Identity.Data.AgriEneryConnectContext _context;

        public IndexModel(Agri_Enery_Connect.Areas.Identity.Data.AgriEneryConnectContext context)
        {
            _context = context;
        }

        public IList<FarmerCategory> FarmerCategory { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.FarmerCategory != null)
            {
                FarmerCategory = await _context.FarmerCategory.ToListAsync();
            }
        }
    }
}
