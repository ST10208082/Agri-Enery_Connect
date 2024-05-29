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

namespace Agri_Enery_Connect.Areas.Identity.Pages.FarmerProducts
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly AgriEneryConnectContext _context;
        private readonly UserManager<Agri_EneryUser> _userManager;

        public IndexModel(AgriEneryConnectContext context, UserManager<Agri_EneryUser> userManager, ILogger<IndexModel> logger)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
        }

        public IList<FarmerProduct> Products { get; set; }

        [BindProperty]
        public FarmerProduct NewProduct { get; set; }


        [BindProperty]
        public IFormFile Image { get; set; }

        public void OnGet()
        {         
            Products = _context.FarmerProduct.ToList();
            if (User.Identity.IsAuthenticated)
            {
                // User is authenticated
            }
            else
            {
                // User is not authenticated
            }

        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                _logger.LogWarning("UserId not founddddddddddd " + user.Id);
                return Unauthorized();
            }

            if (!ModelState.IsValid || _context.FarmerProduct == null || Products == null)
            {
                _logger.LogWarning("noooooooooo");
                return Page();
            }

            

            if (Image != null)
            {
                _logger.LogWarning("Image is populated");
                // Ensure the images folder exists
                var imagesFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
                if (!Directory.Exists(imagesFolderPath))
                {
                    Directory.CreateDirectory(imagesFolderPath);
                }

                // Generate a unique file name
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + Image.FileName;

                // Get the file path
                var filePath = Path.Combine(imagesFolderPath, uniqueFileName);

                // Save the file to the images folder
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await Image.CopyToAsync(fileStream);
                }

                // Save the file name to the database (or other storage)
                NewProduct.ImagePath = uniqueFileName;
            }

            // Set the Users property to the current user's ID
            NewProduct.Users = user.Id;

            // Save NewProduct to the database
            _context.FarmerProduct.Add(NewProduct);
            await _context.SaveChangesAsync();

            return Page();
        }



    }
}
