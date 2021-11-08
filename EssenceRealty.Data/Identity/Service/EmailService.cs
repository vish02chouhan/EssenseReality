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

        public async Task<bool> Execute(string apiKey, string subject, string message, string email)
        {
            if (!Configuration.Default.ApiKey.ContainsKey("api-key"))
            {
                Configuration.Default.ApiKey.Add("api-key", apiKey);
            }
          

            var apiInstance = new TransactionalEmailsApi();
            var senderName = "Essence Realty";
            var senderEmail = "admin@essencerealty.com";
            var sender = new SendSmtpEmailSender(senderName, senderEmail);

            string toEmail = email;
            string toName = email;
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
            catch (Exception)
            {
                throw;
            }

        }
    }
}
