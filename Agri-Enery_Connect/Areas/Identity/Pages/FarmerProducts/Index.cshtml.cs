using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Agri_Energy_Connect_Application.Models;
using Agri_Enery_Connect.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Agri_Enery_Connect.Migrations;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Logging;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Agri_Enery_Connect.Service;
using Microsoft.AspNetCore.Routing.Constraints;
using System.Security.Claims;

namespace Agri_Enery_Connect.Areas.Identity.Pages.FarmerProducts
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IFileService _fileService;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly AgriEneryConnectContext _context;
        private readonly UserManager<Agri_EneryUser> _userManager;

        public IndexModel(
            AgriEneryConnectContext context,
            UserManager<Agri_EneryUser> userManager, 
            ILogger<IndexModel> logger,
             IFileService fileService,
             IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
            this._fileService = fileService;
            this._hostEnvironment = hostEnvironment;
        }

        public IList<FarmerProduct> Products { get; set; }
        public IList<FarmerCategory> Categories { get; set; }

        [BindProperty]
        public FarmerProduct Prod { get; set; }

        public void OnGet()
        {
            Categories = _context.FarmerCategory.ToList();

            var UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            Products = _context.FarmerProduct.Where(p => p.Users == UserId).ToList();
           
        }

        public async Task<IActionResult> OnPostAsync()
        {

            var user = await _userManager.GetUserAsync(User);
            var products = from p in _context.FarmerProduct
                           select p;

            if (user == null)
            {              
                return Unauthorized();
            }
            else
            {
                // Set the Users property to the current user's ID
                Prod.Users = user.Id;
            }

            if (ModelState.IsValid)
            {
                _logger.LogWarning("noooooo");
                return Page();
            }


            //save image to wwwroot/image
            string wwwRootPath = _hostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(Prod.ProductImage.FileName);
            string extension = Path.GetExtension(Prod.ProductImage.FileName);
            Prod.ImagePath = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            string path = Path.Combine(wwwRootPath + "/images/", fileName);
            using(var fileStream = new FileStream(path,FileMode.Create))
            {
                await Prod.ProductImage.CopyToAsync(fileStream);
            }

           



            // Save NewProduct to the database
            _logger.LogWarning("Yessss");
            _context.FarmerProduct.Add(Prod);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Product successfully added.";

            return RedirectToPage("/View/Home/Index");
        }



    }
}
