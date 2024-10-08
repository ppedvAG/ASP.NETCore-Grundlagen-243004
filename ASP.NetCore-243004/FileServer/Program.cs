
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;

namespace FileServer
{
    public class Program
    {
        public const string FILE_PATH = "files";

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();

            var fileProvider = InitFileProvider(builder.Environment, FILE_PATH);

            var app = builder.Build();

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = fileProvider,
                RequestPath = $"/{FILE_PATH}"
            });

            // Zum Anzeigen der Dateien im Browser
            app.UseDirectoryBrowser(new DirectoryBrowserOptions
            {
                FileProvider = fileProvider,
                RequestPath = $"/{FILE_PATH}"
            });

            app.MapControllerRoute("default", "{controller=Files}");

            app.Run();
        }

        private static PhysicalFileProvider InitFileProvider(IWebHostEnvironment environment, string path)
        {
            var rootPath = Path.Combine(environment.ContentRootPath, path);

            if (!Directory.Exists(rootPath))
            {
                Directory.CreateDirectory(rootPath);
            }

            return new PhysicalFileProvider(rootPath);
        }
    }
}
