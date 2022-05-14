using Mail.Contracts;
using System;

namespace Mail.Service
{
    public class MailService : IMailService
    {
        public void SendTestMail()
        {
            Console.WriteLine("This is the email that was sent.");
        }

        public bool TrySendTestMail()
        {
            try
            {
                SendTestMail();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
