using Agri_Enery_Connect.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Agri_Energy_Connect_Application.Models;

namespace Agri_Enery_Connect.Areas.Identity.Data;

public class AgriEneryConnectContext : IdentityDbContext<Agri_EneryUser>
{
    public AgriEneryConnectContext(DbContextOptions<AgriEneryConnectContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

    public DbSet<Agri_Energy_Connect_Application.Models.FarmerCategory> FarmerCategory { get; set; } = default!;

    public DbSet<Agri_Energy_Connect_Application.Models.FarmerProduct> FarmerProduct { get; set; } = default!;
}
