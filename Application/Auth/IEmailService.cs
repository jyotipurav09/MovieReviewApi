namespace Application.Auth
{
    public interface IEmailService
    {
        Task SendEmail(string email, string subject, string body);
        Task SendOtpAsync(string email, string otp, string subject);

    }
}
