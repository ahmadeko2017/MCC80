namespace ClientServer.Controllers;

public interface IEmailHandler
{
    void SendEmail(string toEmail, string subject, string httpEmail);
}