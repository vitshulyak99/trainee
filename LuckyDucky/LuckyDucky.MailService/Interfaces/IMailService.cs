namespace LuckyDucky.MailService.Interfaces
{
    public interface IMailService
    {
        void SendHtmlEmail(string[] recipients, string title, string htmlBody);

        void SendPlainTextEmail(string[] recipients, string title, string plainTextBody);
    }
}
