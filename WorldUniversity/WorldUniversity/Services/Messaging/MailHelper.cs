using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace WorldUniversity.Services.Messaging
{
    public class MailHelper : IMailHelper
    {
        private readonly string email;
        private readonly string password;
        public MailHelper(string email, string password)
        {
            this.email = email;
            this.password = password;
        }
        public async Task SendContactFormAsync(string email, string names, string subject, string content)
        {
            var body = HttpUtility.HtmlEncode(content);

            body = body.Replace(" ", "&nbsp;");
            body = body.Replace("\r\n", "<br>");

            var fromAddress = new MailAddress(this.email, $"{names} - Contact Form");
            var toAddress = new MailAddress(this.email);

            string bodyBuilder = "<div style=\"background-color: #BADEF7;\"><a href=\"https://localhost:44313\" title=\"HTML Email Check\" target=\"_blank\">"
                + "<p style=\"text-align: center;\">"
                + "</p>"
                + "</a>"
                + "<p style=\"text-align: center;\">"
                + "<font size=\"5\">"
                + $"<b>Email:</b> {HttpUtility.HtmlEncode(email)}"
                + "<br/>"
                + $"<b>Name:</b> {HttpUtility.HtmlEncode(names)}"
                + "</font>"
                + "</p>"
                + "<hr>"
                + "<font size=\"4\">"
                + "<div style=\"margin-left: 15%; margin-right: 15%;\">"
                + body
                + "</div>"
                + "</font>"
                + "<hr>"
                + "<a href=\"https://localhost:44313\" title=\"HTML Email Check\" target=\"_blank\">"
                + "</a>"
                + "</div>";

            await this.SendMessageAsync(fromAddress, toAddress, subject, bodyBuilder);
        }

        public async Task SendFromIdentityAsync(string email, string subject, string fullName, string url)
        {
            var fromAddress = new MailAddress(this.email);
            var toAddress = new MailAddress(email);

            string bodyBuilder = "<div style=\"background-color: #BADEF7;\"><a href=\"https://localhost:44313\" title=\"HTML Email Check\" target=\"_blank\">"
                + "<p style=\"text-align: center;\">"
                + "</p>"
                + "</a>"
                + "<hr>"
                + "<font size=\"4\">"
                + "<div style=\"margin-left: 15%; margin-right: 15%;\">"
                + "<div style=\"text-align: center;\">"
                + $"Welcome to WorldUniveristy {fullName},"
                + "<br>"
                + "<br>"
                + "<br>"
                + "<br>"
                + $"<a href=\"{url}\" style=\"background-color:#134668;border:1px solid #134668;border-radius:5px;color:#ffffff;display:inline-block;font-size:16px;line-height:44px;text-align:center;text-decoration:none;width:150px;\">Click here to confirm your email</a>"
                + "</div>";

            await this.SendMessageAsync(fromAddress, toAddress, subject, bodyBuilder);
        }

        private async Task SendMessageAsync(MailAddress fromAddress, MailAddress toAddress, string subject, string body)
        {
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(this.email, this.password),
            };
            using var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true,
            };

            await smtp.SendMailAsync(message);
        }
    }
}
