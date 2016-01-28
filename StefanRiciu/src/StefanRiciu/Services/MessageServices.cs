using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using SendGrid;

namespace StefanRiciu.Services
{
    // This class is used by the application to send Email and SMS
    // example from: https://docs.asp.net/en/1.0.0-beta8/security/2fa.html
    public class AuthMessageSender : IEmailSender, ISmsSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            // Plug in your email service here to send an email.

            // Create the email object first, then add the properties.
            var myMessage = new SendGridMessage();

            myMessage.AddTo(email);
            
            // Add the message properties.
            myMessage.From = new MailAddress("riciustef@gmail.com", "Ștefan Rîciu");
            myMessage.Subject = subject;
            myMessage.Text = message;
            myMessage.Html = message;

            var credentials = new NetworkCredential("azure_eb4b422357889b9c5ff845f2ad28d7de@azure.com", "fastest23");
            
            // Create a Web transport for sending email.
            var transportWeb = new Web(credentials);
            
            // Send the email.
            if (transportWeb != null)
            {
                return transportWeb.DeliverAsync(myMessage);
            }
            else
            {
                return Task.FromResult(0);
            }
        }

        // example from: https://docs.asp.net/en/1.0.0-beta8/security/2fa.html
        public Task SendSmsAsync(string number, string message)
        {
            var twilio = new Twilio.TwilioRestClient(
            "AC1dd973cc6df8b1173f1307c1147bd7dd",           // Account Sid from dashboard
            "a0d11fea01ce936f428e55776917bc2f");    // Auth Token

            var result = twilio.SendMessage("+14695950494", number, message);
            return Task.FromResult(0);
        }
    }
}
