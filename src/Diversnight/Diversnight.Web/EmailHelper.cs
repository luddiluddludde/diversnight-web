using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using Mandrill;

namespace Diversnight.Web
{
    public class EmailHelper
    {
        private static EmailHelper _instance;
        private static MandrillApi _api;

        private EmailHelper()
        {
            _api = new MandrillApi(Config.Mandrill.ApiKey);
        }

        public static EmailHelper Instance
        {
            get { return _instance ?? (_instance = new EmailHelper()); }
        }

        public bool SendMail(string destination, string subject, string message)
        {
            return SendMail(destination, subject, message, "no-reply@diversnight.com", "Diversnight");
        }
        public bool SendMail(string destination, string subject, string message, string senderEmail, string senderName)
        {
            try
            {
                var email = new EmailMessage()
                {
                    from_name = senderName,
                    from_email = senderEmail,
                    to = new List<EmailAddress> {new EmailAddress(destination)},
                    subject = subject,
                    html = message,
                    auto_text = true
                };

                var results = _api.SendMessage(email);
                if (results.Any(r => r.Status == EmailResultStatus.Invalid || r.Status == EmailResultStatus.Rejected))
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to send email", ex);
            }
        }
    }
}