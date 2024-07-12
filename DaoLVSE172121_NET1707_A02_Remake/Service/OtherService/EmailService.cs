using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Service.OtherService
{
    public class EmailService
    {
        public async Task SendConfirmationEmailAsync(string email, string callbackUrl)
        {
            var message = new MailMessage();
            message.From = new MailAddress("daolvse172121@fpt.edu.vn");
            message.To.Add(email);
            message.Subject = "Xác nhận tài khoản của bạn";
            message.Body = GenerateEmailBody(callbackUrl);
            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient("smtp.gmail.com"))
            {
                smtp.Port = 587; // Hoặc 465 nếu bạn sử dụng SSL
                smtp.Credentials = new NetworkCredential("daolvse172121@fpt.edu.vn", "kunu yiqf gpkr xcvj");
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(message);
            }
        }

        private string GenerateEmailBody(string callbackUrl)
        {
            return $@"
            <html>
            <head>
                <style>
                    body {{
                        font-family: Arial, sans-serif;
                        background-color: #f4f4f4;
                        margin: 0;
                        padding: 0;
                    }}
                    .container {{
                        width: 100%;
                        padding: 20px;
                        background-color: #ffffff;
                        box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
                        border-radius: 10px;
                        margin: 20px auto;
                        max-width: 600px;
                    }}
                    .header {{
                        background-color: #007bff;
                        color: #ffffff;
                        padding: 10px 0;
                        text-align: center;
                        border-radius: 10px 10px 0 0;
                    }}
                    .content {{
                        padding: 20px;
                        text-align: center;
                    }}
                    .button {{
                        background-color: #28a745;
                        color: #ffffff;
                        padding: 10px 20px;
                        text-decoration: none;
                        border-radius: 5px;
                        font-weight: bold;
                    }}
                    .footer {{
                        margin-top: 20px;
                        text-align: center;
                        color: #888888;
                    }}
                </style>
            </head>
            <body>
                <div class='container'>
                    <div class='header'>
                        <h1>Xác nhận tài khoản của bạn</h1>
                    </div>
                    <div class='content'>
                        <p>Chào bạn,</p>
                        <p>Vui lòng xác nhận tài khoản của bạn bằng cách nhấn vào nút dưới đây:</p>
                        <a href='{callbackUrl}' class='button'>Xác nhận tài khoản</a>
                    </div>
                    <div class='footer'>
                        <p>Nếu bạn không tạo tài khoản này, vui lòng bỏ qua email này.</p>
                    </div>
                </div>
            </body>
            </html>";
        }

        public string GenerateConfirmationLink(string userId, string email, string token, string baseUrl)
        {
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["userId"] = userId;
            queryString["email"] = email;
            queryString["token"] = token;
            var callbackUrl = $"{baseUrl}/Customers/Confirm?{queryString}"; // Thay đổi đường dẫn ở đây
            return callbackUrl;
        }
    }
}
