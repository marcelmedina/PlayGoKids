namespace DependencyInjectionService
{
    public interface IEmailService
    {
        void SendEmail(string emailTo, string subject, string body);
    }
}
