using dotnet_code_challange.Engine;
using dotnet_code_challange.RaceEngine.Interface;
using dotnet_code_challange.RaceEngine.OutputService;
using dotnet_code_challenge.Engine.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace dotnet_code_challenge
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                //setup our DI
                var serviceProvider = new ServiceCollection()
                    .AddSingleton<JsonEngine>()
                    .AddSingleton<XmlEngine>()
                    .AddSingleton<RaceImportWorker>()
                    .AddSingleton<IOutputService>(s => new ConsoleOutputService())
                    .BuildServiceProvider();

                // reading file path from environment variable
                // environment variable is easy to pass in CI/CD and DockerCompose
                // we can pass different paths for different deployment, without making any change in any application config files
                var wolverhamptonFilePath = Environment.GetEnvironmentVariable("WolverhamptonFiles");
                var caufieldFilePath = Environment.GetEnvironmentVariable("CaufieldFiles");

                var worker = serviceProvider.GetService<RaceImportWorker>();
                await worker.StartProcessing(wolverhamptonFilePath, caufieldFilePath);
            }
            catch (AggregateException ae)
            {
                foreach (var e in ae.InnerExceptions)
                {
                    Console.WriteLine(ae.InnerException);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
