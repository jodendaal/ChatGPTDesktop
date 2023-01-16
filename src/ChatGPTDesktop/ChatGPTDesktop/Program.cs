using ChatGPTDesktop.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace ChatGPTDesktop
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }
      
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            ServiceProvider = CreateHostBuilder().Build().Services;
            Application.Run(ServiceProvider.GetService<Form1>());
        }
       
        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => {
                    services.AddSingleton<IFormFactory,FormFactory>();

                    //Add all forms
                    var forms = typeof(Program).Assembly
                    .GetTypes()
                    .Where(t => t.BaseType ==  typeof(Form))
                    .ToList();

                    forms.ForEach(form =>
                    {
                        services.AddTransient(form);
                    });
                });
        }
    }
}