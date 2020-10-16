using LuckyDucky.MailService.Interfaces;

namespace LuckyDucky.MailService {
    public class MailService : IMailService {
        public void SendHtmlEmail(string[] recipients, string title, string htmlBody) {
            // mail service implementation will be here
        }

        public void SendPlainTextEmail(string[] recipients, string title, string plainTextBody) {
            // mail service implementation will be here
        }
    }
}
