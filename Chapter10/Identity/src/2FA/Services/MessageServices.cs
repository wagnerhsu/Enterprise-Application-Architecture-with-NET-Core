using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace _2FA.Services
{
    // This class is used by the application to send Email and SMS
    // when you turn on two-factor authentication in ASP.NET Identity.
    // For more details see this link http://go.microsoft.com/fwlink/?LinkID=532713
    public class AuthMessageSender : IEmailSender, ISmsSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            // Plug in your email service here to send an email.
            return Task.FromResult(0);
        }

        public Task SendSmsAsync(string number, string message)
        {
            try
            {
                string accountSid = "AC1a78be46e2ca135ef04b627a9bb4c14f";
                string authToken = "3242273e2c9d59868c003d4fb69a56d8";
                //Twilio.TwilioClient.Init(accountSid, authToken);
                //var restClient = new TwilioRestClient(accountSid, authToken);

                //  var res = new MessageCreator(new PhoneNumber(number), new PhoneNumber("002565488029"), message).Execute(restClient);
                //var result = new MessageCreator(accountSid,
                //             new PhoneNumber("+12345678901"),  // To number
                //             new PhoneNumber("+12345678901"),  // Twilio From number
                //             "Hello from C#").ExecuteAsync(restClient).Result;

                string TwilioSmsEndpointFormat = "https://api.twilio.com/2010-04-01/Accounts/{0}/Messages.json";
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Basic",
                Convert.ToBase64String(Encoding.UTF8.GetBytes(
                     string.Format("{0}:{1}", accountSid, authToken)
                     )));

                var keypair = new List<KeyValuePair<string, string>>();
                keypair.Add(new KeyValuePair<string, string>("To", number));
                keypair.Add(new KeyValuePair<string, string>("From", "2565488029"));
                keypair.Add(new KeyValuePair<string, string>("Body", message));

                var content = new FormUrlEncodedContent(keypair);

                var postUrl = string.Format(CultureInfo.InvariantCulture, TwilioSmsEndpointFormat, accountSid);

                var response = client.PostAsync(postUrl, content).Result;
                
            }

            catch (Exception ex) { }



            return Task.FromResult(0);
        }
    }
}
