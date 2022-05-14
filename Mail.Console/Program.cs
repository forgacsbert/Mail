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

            var mailService = host.Services.GetRequiredService<IMailService>();

            Console.WriteLine("Sending email..");

            mailService.SendTestMail();

            Console.WriteLine("Email sent!");

            Console.ReadKey();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                    services.AddTransient<IMailService, MailService>());
        }
    }
}
