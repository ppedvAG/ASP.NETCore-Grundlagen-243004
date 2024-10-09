using BusinessLogic.Contracts;
using BusinessLogic.Data;
using BusinessLogic.Services;
using DemoMvcApp.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace DemoMvcApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
                .ReadFrom.Configuration(builder.Configuration)
                .CreateLogger();

            builder.Host.UseSerilog();

            builder.Services.AddScoped<IRecipeService, RecipeService>();
            builder.Services.AddScoped<IOrderService, OrderService>();

            // Optionen fuer den FileServer aufloesen
            builder.Services.AddTransient<IPhotoService, FileService>();
            var fileConfig = builder.Configuration.GetSection("FileServer");
            builder.Services.Configure<FileServiceOptions>(fileConfig);
            builder.Services.AddHttpClient();

            // Datenbankverbindung konfigurieren
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<FoodDeliveryDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            builder.Services.AddSqlServer<AccountDbContext>(builder.Configuration.GetConnectionString("AccountConnection"));
            builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<AccountDbContext>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();
            try
            {
                Log.Information("Starting web host");

                StartApp(app);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private static void StartApp(WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
