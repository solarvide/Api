using Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App
{
    public class ProjectMailSender
    {
        public static async Task Send(string emailTo, string subject, string bodyTitle, string message, string userFirstName, Microsoft.AspNetCore.Http.HttpRequest request)
        {
            string hello = Translator.Transl("mail_hello", "Hello", request);
            string team = Translator.Transl("mail_team", "Team", request);
            string preMail = Translator.Transl("mail_premail", "Do you have any doubt? Contact us at", request);
            string socialMedia = Translator.Transl("mail_socialmedia", "Social Media", request);
            string accessWebsite = Translator.Transl("mail_access_website", "Access Website", request);

            Tools.SendEmailAsync(emailTo, subject, message, bodyTitle, hello, userFirstName, team, preMail, socialMedia, accessWebsite);
        }
    }
}
