using Twilio.Clients;
using Twilio.Http;
using Twilio.Types;

namespace automated_SMS_delivery_Service_Twilio.Services
{
    public class TwilioClientService : ITwilioRestClient
    {
        private readonly ITwilioRestClient _innerClient;

        public string AccountSig => _innerClient.AccountSid;
        public string Regio => _innerClient.Region;
        public Twilio.Http.HttpClient HttpClient => _innerClient.HttpClient;


        public string AccountSid => _innerClient.AccountSid;

        public string Region => _innerClient.Region;

        public TwilioClientService(IConfiguration config, IHttpClientFactory httpClientFactory)
        {
            var accountSid = config["Twilio:AccountSid"];
            var authToken = config["Twilio:AuthToken"];
            var httpClient = httpClientFactory.CreateClient();

            httpClient.DefaultRequestHeaders.Add("X-Custom-Header", "CustomTwilioRestClient-Demo");

            _innerClient = new TwilioRestClient(accountSid, authToken, httpClient: new SystemNetHttpClient(httpClient));
        }


        public Response Request(Request request) => _innerClient.Request(request);

        public Task<Response> ResponseAsync(Request request) => _innerClient.RequestAsync(request);

        public Task<Response> RequestAsync(Request request) => _innerClient.RequestAsync(request);
    }
}