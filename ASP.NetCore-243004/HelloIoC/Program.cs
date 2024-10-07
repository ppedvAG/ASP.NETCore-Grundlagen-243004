using BusinessLogic.Contracts;
using BusinessLogic.Services;

namespace HelloIoC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Singleton wird einmal erzeugt und gilt fuer den gesammten Lebenszyklus der App
            //builder.Services.AddSingleton<IRecipeService, RecipeService>();

            // Scoped gilt fuer den Lebenszyklus eines Requests an den Server
            //builder.Services.AddScoped<IRecipeService, RecipeService>();

            // Transient wird immer neu erzeugt
            builder.Services.AddTransient<IRecipeService, RecipeService>();

            builder.Services.AddControllers();

            var app = builder.Build();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Recipes}/{action=Get}");

            app.Run();
        }
    }
}
