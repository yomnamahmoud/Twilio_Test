using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twilio.Mvc;
using Twilio.TwiML;
using Twilio.TwiML.Mvc;
namespace Twilio.Controllers
{
    public class WebhookController : TwilioController
    {
        //
        // GET: /Webhook/
        [HttpPost]
        public ActionResult Index(SmsRequest request)
        {
           var response = new TwilioResponse();
           response.Message("Hello World");
           return TwiML(response);


            //////sending reply
           string AccountSid = "{{ account_sid }}";
           string AuthToken = "{{ auth_token }}";
           var twilio = new TwilioRestClient(AccountSid, AuthToken);

           var message = twilio.SendMessage("+1253440106", "+201006728219", "Brooklyn is in the house!");
            //from to body (diference between send message and send sms)
           Console.WriteLine(message.Sid);
        }

       /* [HttpPost]      ///sendig message seperate function
        public JsonResult SendSMS(string message, string custid)
        {
            string AccountSid = "Your Twilio Account SID";
            string AuthToken = "Your Twilio Authentication Token";
            var twilio = new TwilioRestClient(AccountSid, AuthToken);
            var sms = twilio.SendMessage("From Number", "To Number", "Message Body");
            var status = sms.Status;
            return status;
        }
        * */
        

    }
}
