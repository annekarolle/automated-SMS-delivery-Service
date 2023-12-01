using automated_SMS_delivery_Service_Twilio.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Twilio.Clients;
using Twilio.Types; 
using Twilio.Rest.Api.V2010.Account;


namespace automated_SMS_delivery_Service_Twilio.Controller
{
    public class SendSMSController : ControllerBase
    {
        private readonly ITwilioRestClient _client;
        private readonly IConfiguration _config;


        public SendSMSController(ITwilioRestClient client, IConfiguration config)
        {
            _client = client;
            _config = config;

        }

        [HttpPost]
        [Route("sendSMSTwilio")]
        [AllowAnonymous]
        public IActionResult SendSMSTwilio(SMSDTO model)
        {

            var message = MessageResource.Create(
                to: new PhoneNumber(model.To),
                from: new PhoneNumber("Twilio Phone Number"),
                body: model.Message,
                client: _client
                );

            return Ok("Success");
        }
    }
}
