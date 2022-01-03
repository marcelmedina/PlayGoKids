namespace DependencyInjectionService
{
    public interface IEmailService
    {
        void SendEmail(string emailTo, string subject, string body);
    }

    public class EmailService : IEmailService
    {
        public void SendEmail(string emailTo, string subject, string body)
        {
            // TODO: Send Email
        }
    }
}
