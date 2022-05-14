namespace Mail.Contracts
{
    public interface IMailService
    {
        /// <summary>
        /// Method used to send a test mail.
        /// Throws exception.
        /// </summary>
        void SendTestMail();

        /// <summary>
        /// Method used to send a test mail
        /// </summary>
        /// <returns>Returns true if mail was successfully sent, false if not.</returns>
        bool TrySendTestMail();
    }
}
