using System.Net.Mail;

namespace SIRIUS.Rapor.WebApi.Services
{
    public class EmailService
    {
        public enum EmailStatus
        {
            Success,
            Error
        }
        public async Task<EmailStatus> SendForgotEmail(string url,string to)
        {
            MailMessage message = new MailMessage();

            #region Body Created
            var body = string.Empty;
            FileStream stream = File.Open("\\appserver\\" + "fotgotpassword.html", FileMode.OpenOrCreate);
            using (StreamReader reader = new StreamReader(stream))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("@LINK", url);
            #endregion

            message.Body = body;
            message.From = new MailAddress("sirius@ekofactoring.com");
            message.To.Add(new MailAddress(to));
            message.IsBodyHtml = true;
            message.Priority = MailPriority.High;
            
            SmtpClient smtp = new SmtpClient("172.34.1.6");
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            await smtp.SendMailAsync(message);

            return EmailStatus.Success;
        }
    }
}