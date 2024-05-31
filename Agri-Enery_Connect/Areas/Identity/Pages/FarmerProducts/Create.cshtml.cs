using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Agri_Energy_Connect_Application.Models;
using Agri_Enery_Connect.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;

namespace Agri_Enery_Connect.Areas.Identity.Pages.FarmerProducts
{
    public class CreateModel : PageModel
    {
        private readonly AgriEneryConnectContext _context;

        public CreateModel(AgriEneryConnectContext context)
        {
            _context = context;
        }

        public IList<FarmerProduct> FarmerProduct { get; set; }
        public IList<FarmerCategory> Categories { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? Category { get; set; }

        public void OnGet()
        {
            Categories = _context.FarmerCategory.ToList();
            var products = from p in _context.FarmerProduct
                           select p;

            if (!string.IsNullOrEmpty(SearchTerm))
            {
                products = products.Where(p => p.ProductName.Contains(SearchTerm));
            }
            else if(Category.HasValue && Category > 0)
            {
                products = products.Where(p => p.CategoryID == Category);
            }

            FarmerProduct = products.ToList();
        }
    }
}
