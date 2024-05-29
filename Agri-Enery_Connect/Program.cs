using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Agri_Enery_Connect.Areas.Identity.Data;
using Microsoft.Extensions.Options;


namespace Agri_Enery_Connect
{
    public class Program
    {
        public static async Task Main(String[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("AgriEneryConnectContextConnection") ?? throw new InvalidOperationException("Connection string 'AgriEneryConnectContextConnection' not found.");

            builder.Services.AddDbContext<AgriEneryConnectContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddDefaultIdentity<Agri_EneryUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AgriEneryConnectContext>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddRazorPages();

            builder.Services.Configure<IdentityOptions>(Options =>
            {
                Options.User.RequireUniqueEmail = true; 
                Options.Password.RequireUppercase = false;
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();

            using (var scope = app.Services.CreateScope())
            {
                var roleManager =
                    scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                var roles = new[] { "Farmer", "GreenTech", "Employee" };

                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                        await roleManager.CreateAsync(new IdentityRole(role));

                }
            }
            


            app.Run();
        }
    }
  

}
