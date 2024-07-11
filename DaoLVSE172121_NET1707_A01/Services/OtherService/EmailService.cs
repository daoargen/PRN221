using System.Net;
using System.Net.Mail;
using System.Web;

public class EmailService
{
    public async Task SendConfirmationEmailAsync(string email, string callbackUrl)
    {
        var message = new MailMessage();
        message.From = new MailAddress("daolvse172121@fpt.edu.vn");
        message.To.Add(email);
        message.Subject = "Xác nhận tài khoản của bạn";
        message.Body = $"Vui lòng xác nhận tài khoản của bạn bằng cách nhấn vào <a href='{callbackUrl}'>liên kết này</a>.";
        message.IsBodyHtml = true;

        using (var smtp = new SmtpClient("smtp.gmail.com"))
        {
            smtp.Port = 587; // Hoặc 465 nếu bạn sử dụng SSL
            smtp.Credentials = new NetworkCredential("daolvse172121@fpt.edu.vn", "kunu yiqf gpkr xcvj");
            smtp.EnableSsl = true;
            await smtp.SendMailAsync(message);
        }
    }

    public string GenerateConfirmationLink(string userId, string email, string token, string baseUrl)
    {
        var queryString = HttpUtility.ParseQueryString(string.Empty);
        queryString["userId"] = userId;
        queryString["email"] = email;
        queryString["token"] = token;
        var callbackUrl = $"{baseUrl}/confirm?{queryString}";
        return callbackUrl;
    }
}
