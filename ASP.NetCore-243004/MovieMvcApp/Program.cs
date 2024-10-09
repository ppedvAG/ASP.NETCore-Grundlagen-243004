using BusinessLogic.Contracts;
using BusinessLogic.Services;
using Microsoft.EntityFrameworkCore;
using MovieMvcApp.Middleware;
using MovieStore.Contracts;
using MovieStoreApp.Data;
using MovieStoreApp.Services;

namespace MovieMvcApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddTransient<IMovieService, MovieService>();
            builder.Services.AddTransient<IPhotoService, FileService>();
            builder.Services.Configure<FileServiceOptions>(builder.Configuration.GetSection("FileServer"));
            builder.Services.AddHttpClient();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<MovieDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseRequestCultureMiddleware();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
