using Lab002_DependencyInjection.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Lab002_DependencyInjection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var provider = RegisterTypes();

            var operationSingleton = provider.GetService<IOperationSingleton>();
            Console.WriteLine("Singleton #1: " + operationSingleton.OperationId);

            var operationSingleton2 = provider.GetService<IOperationSingleton>();
            Console.WriteLine("Singleton #2: " + operationSingleton2.OperationId);

            var operationTransient = provider.GetService<IOperationTransient>();
            Console.WriteLine("Transient #1: " + operationTransient.OperationId);

            var operationTransient2 = provider.GetService<IOperationTransient>();
            Console.WriteLine("Transient #2: " + operationTransient2.OperationId);

            var classicInstance = new ConsumerClass(operationTransient, operationSingleton);

            var ctorParams = typeof(ConsumerClass).GetConstructors()[0].GetParameters();
            foreach (var item in ctorParams)
            {
                Console.WriteLine($"Parameter: {item.ParameterType} {item.Name}");
            }

            // Beispiel wie mit Reflection eine Klasse (Service) dynamisch mit Abhängigkeiten (Dependencies) erzeugt wird
            // Das wird vom ASP.Net Core Framework automatisch übernommen
            ConsumerClass dynamicInstance = (ConsumerClass)Activator.CreateInstance(typeof(ConsumerClass), operationTransient, operationSingleton);

            Console.ReadLine();
        }

        private static ServiceProvider RegisterTypes()
        {
            var container = new ServiceCollection();
            container.AddSingleton<IOperationSingleton, OperationService>();
            container.AddScoped<IOperationScoped, OperationService>();
            container.AddTransient<IOperationTransient, OperationService>();
            return container.BuildServiceProvider();
        }

        public class ConsumerClass
        {
            public ConsumerClass(IOperationTransient transient, IOperationSingleton singleton)
            {
                Console.WriteLine("Foo says " + transient.OperationId);
            }
        }
    }
}
