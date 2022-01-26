using System;
using System.IO;
using Azure.Identity;
using FunctionWithKeyVault;
using FunctionWithKeyVault.Models;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

[assembly: FunctionsStartup(typeof(Startup))]
namespace FunctionWithKeyVault
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var executionContextOptions = builder.Services.BuildServiceProvider().GetService<IOptions<ExecutionContextOptions>>().Value;
            var appDirectory = executionContextOptions.AppDirectory;

            var config = new ConfigurationBuilder()
                .SetBasePath(appDirectory)
                .AddJsonFile(Path.Combine(appDirectory, "settings.json"), optional: true, reloadOnChange: true)
                .AddAzureKeyVault(new Uri("https://youruri.vault.azure.net/"), new DefaultAzureCredential())
                .Build();

            builder.Services.Configure<SecretSettings>(config.GetSection("SecretSettings"));

            builder.Services.AddSingleton<IConfiguration>(config);
        }
    }
}
