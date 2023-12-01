 
using Twilio.Clients;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types; 
using Twilio.Http;
 



namespace automated_SMS_delivery_Service_Twilio.Services
{
    public class TwilioAutomatedSMSSendService : BackgroundService
    {

        private readonly IConfiguration _config;
        private readonly IHttpClientFactory httpClientFactory;


        public TwilioAutomatedSMSSendService(IConfiguration config, IHttpClientFactory httpClientFactory)
        {
            _config = config;
            this.httpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// Executes the automated trigger function at the defined schedule
        /// </summary>
        /// <param name="stoppingToken"></param>
        /// <returns></returns>
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var startTime = new TimeSpan(12, 18, 0);

            while (!stoppingToken.IsCancellationRequested)
            {
                var now = DateTime.Now;
                var timeRemaining = startTime - now.TimeOfDay;

                if (timeRemaining < TimeSpan.Zero)
                {
                    timeRemaining = TimeSpan.FromHours(24) + timeRemaining;
                }

                await Task.Delay(timeRemaining, stoppingToken);

                ExecuteSendSMSAsync();
            }
        }


        /// <summary>
        /// Execute sms Delivery message 
        /// </summary>
        public void ExecuteSendSMSAsync()
        {
            var phoneNumberList = new List<DTO.SMSDTO>();
            foreach (var list in phoneNumberList)
            {
                SendSMS(list);
            }

        }

        /// <summary>
        /// Sends SMS through a provided list of phone numbers.
        /// </summary>
        /// <param name="model"></param>
        private void SendSMS(DTO.SMSDTO model)
        {
            var accountSid = _config["Twilio:AccountSid"];
            var authToken = _config["Twilio:AuthToken"];
            var httpClient = httpClientFactory.CreateClient();
            httpClient.DefaultRequestHeaders.Add("X-Custom-Header", "CustomTwilioRestClient-Demo");
            var clientTwilio = new TwilioRestClient(accountSid, authToken, httpClient: new SystemNetHttpClient(httpClient));
            
            try
            {
                var message = MessageResource.Create(
                to: new PhoneNumber("+55" + model.To),
                from: new PhoneNumber("Twilio Phone Number"),
                body:model.Message,
                client: clientTwilio);
                                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }


    }
}
