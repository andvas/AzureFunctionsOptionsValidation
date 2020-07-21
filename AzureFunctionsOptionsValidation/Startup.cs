using AzureFunctionsOptionsValidation;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

[assembly: FunctionsStartup(typeof(Startup))]
namespace AzureFunctionsOptionsValidation
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddLogging();

            builder.Services.AddSingleton<ITester, Tester>();

            builder.Services.Replace(ServiceDescriptor.Transient(typeof(IOptionsFactory<>), typeof(OptionsFactory<>)));
            builder.Services
                   .AddOptions<TesterSettings>()
                   .Configure<IConfiguration>((settings, config) =>
                   {
                       config.GetSection("DoesntExist").Bind(settings);
                   })
                   .ValidateDataAnnotations();
        }
    }
}
