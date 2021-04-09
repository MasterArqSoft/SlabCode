namespace CodeFirst.Core.Interfaces
{
    public interface IEmailService
    {
        void Send(string to, string subject, string html);
    }
}