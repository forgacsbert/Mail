using Mail.Contracts;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace Mail.Service
{
    public class MailService : IMailService
    {
        private readonly IConfiguration configuration;

        public MailService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task SendTestMailAsync()
        {
            string apiKey = configuration["AppSettings:MailSecret"];

            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("adrian.petrisor.delivery@gmail.com", "Freight Engineer");
            var subject = "Sending with SendGrid is Fun";
            var to = new EmailAddress("forgacsbert@gmail.com");
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            await client.SendEmailAsync(msg);
        }

        public async Task<bool> TrySendTestMail()
        {
            try
            {
                await SendTestMailAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
