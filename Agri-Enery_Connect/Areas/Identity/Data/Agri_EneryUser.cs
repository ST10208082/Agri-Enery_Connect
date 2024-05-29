using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Agri_Enery_Connect.Areas.Identity.Data;

// Add profile data for application users by adding properties to the Agri_EneryUser class
public class Agri_EneryUser : IdentityUser
{
    [PersonalData]
    [Column(TypeName = "nvarchar(100)")]
    public string FirstName { get; set; }

    [PersonalData]
    [Column(TypeName = "nvarchar(100)")]
    public string LastName { get; set; }

    [Required]
    public string Role { get; set; } // Add this line to include role
    
    [PersonalData]
    [Column(TypeName = "nvarchar(100)")]
    public string Country { get; set; }

    [PersonalData]
    [Column(TypeName = "nvarchar(100)")]
    public string Suburb { get; set; }

    [PersonalData]
    [Column(TypeName = "nvarchar(100)")]
    public string Street { get; set; }

    [PersonalData]
    [Column(TypeName = "date")]
    public DateTime DOB { get; set; }



}


