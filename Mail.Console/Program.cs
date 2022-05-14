using Mail.Contracts;
using Mail.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Mail
{
    class Program
    {
        public static void Main(string[] args)
        {
            using var host = CreateHostBuilder(args).Build();

            SendTestMail(host.Services);

            Console.ReadKey();
        }

        private static void SendTestMail(IServiceProvider services)
        {
            Console.WriteLine("Sending email..");

            var mailService = services.GetRequiredService<IMailService>();

            mailService.SendTestMailAsync().Wait();

            Console.WriteLine("Email sent!");
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                    services.AddTransient<IMailService, MailService>());
        }
    }
}
