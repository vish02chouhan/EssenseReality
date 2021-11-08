using EssenceRealty.Data.Identity.Contract;
using EssenceRealty.Data.Identity.Models;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;
using sib_api_v3_sdk.Api;
using sib_api_v3_sdk.Client;
using sib_api_v3_sdk.Model;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace EssenceRealty.Data.Identity.Service
{
    public class EmailService : IEmailService
    {

        public Task<bool> SendEmail(Email email)
        {
            string sendGridApiKey = Environment.GetEnvironmentVariable("EssenceEmailSendGrid");
            return Execute(sendGridApiKey, email.Subject, email.Body, email.To);
        }

        public async Task<bool> Execute1(string apiKey, string subject, string message, string email)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("vivekv0288@gmail.com", "Password Recovery"),
                Subject = subject,
                PlainTextContent = null,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email));

            // Disable click tracking.
            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            msg.SetClickTracking(false, false);

            var response = await client.SendEmailAsync(msg);

            return response.IsSuccessStatusCode;
        }
        public async Task<bool> Execute2(string apiKey, string subject, string message, string email)
        {
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("test@example.com", "Example User");
            var to = new EmailAddress(email, "Example User");
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);

            return true;
        }
        public async Task<bool> Execute(string apiKey, string subject, string message, string email)
        {
            if (!Configuration.Default.ApiKey.ContainsKey("api-key"))
            {
                Configuration.Default.ApiKey.Add("api-key", apiKey);
            }
          

            var apiInstance = new TransactionalEmailsApi();
            var senderName = "John Doe";
            var senderEmail = "example@example.com";
            var sender = new SendSmtpEmailSender(senderName, senderEmail);

            string toEmail = email;
            string toName = "John Doe";
            SendSmtpEmailTo smtpEmailTo = new SendSmtpEmailTo(toEmail, toName);
            List<SendSmtpEmailTo> to = new List<SendSmtpEmailTo>();
            to.Add(smtpEmailTo);


            try
            {
                var sendSmtpEmail = new SendSmtpEmail(sender, to, null, null, message, null,
                    subject);

                CreateSmtpEmail result = await apiInstance.SendTransacEmailAsync(sendSmtpEmail);
                return true;
            }
            catch (Exception e)
            {
                throw;
            }

        }
    }
}
