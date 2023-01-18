using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace Util.Email
{
    public class EmailTools
    {
        public static async Task SendEmailExecute(string email, string subject, string message, string title ="Read this message", string hello = "Hello", string userFirstName = "User", string team = "Team", string rodapePreMail = "Do you have any doubt? Contact us at", string socialMedia = "Social Media", string accessWebSite = "Access our website")
        {
            try
            {
                string toEmail = email;

                MailMessage mail = new MailMessage()
                {
                    From = new MailAddress(Tools.GetAppSetting("EmailUsername"), Tools.GetAppSetting("EmailFromDisplay"))
                };

                mail.To.Add(new MailAddress(toEmail));

                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.Normal;
                mail.Subject = subject;


                mail.Body = Template1.Replace("{0}", title).Replace("{1}", hello).Replace("{2}", userFirstName).Replace("{3}", message).Replace("{4}", team).Replace("{5}", rodapePreMail).Replace("{6}", socialMedia).Replace("{7}", accessWebSite);


                //outras opções
                //mail.Attachments.Add(new Attachment(arquivo));

                using (SmtpClient smtp = new SmtpClient())
                //using (SmtpClient smtp = new SmtpClient(Tools.GetAppSetting("EmailPrimaryDomain")))
                {
                    if (Tools.GetAppSetting("DeliveryMethod") == "network") smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                    smtp.Host = Tools.GetAppSetting("EmailPrimaryDomain");
                    smtp.Port = Convert.ToInt32(Tools.GetAppSetting("EmailPrimaryPort"));
                    smtp.Credentials = new System.Net.NetworkCredential(Tools.GetAppSetting("EmailUsername"), Tools.GetAppSetting("EmailPassword"));
                    smtp.EnableSsl = Convert.ToBoolean(Tools.GetAppSetting("EmailEnableSSL"));
                    smtp.UseDefaultCredentials = Convert.ToBoolean(Tools.GetAppSetting("UseDefaultCredentials"));

                    //Não está funcionando sem o await
                    await smtp.SendMailAsync(mail);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// 0 - Titulo
        /// 1 - Hello
        /// 2 - Nome usuário
        /// 3 - Corpo do email
        /// 4 - Team
        /// 5 - PreMail
        /// 6 - SocialMedia
        /// 7 - Acesse o site
        /// </summary>
        protected static string Template1 { get; set; } = "<html><head><meta http-equiv=\"content-Type\" content=\"text/html; charset=utf-8\" /><link rel=\"preconnect\" href=\"https://fonts.gstatic.com\"><link href=\"https://fonts.googleapis.com/css2?family=Poppins:wght@400;700&display=swap\" rel=\"stylesheet\"></head><body><style type=\"text/css\">​ html,body{margin:0;padding:0}@import url('https://fonts.googleapis.com/css2?family=Poppins:wght@400;700&display=swap');</style><table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"width: 100%; background: #e5e5e5\"><tbody><tr><td style='padding: 5%;'><table align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"width:100%; max-width:600px; background: #ffffff; margin-bottom: 50px;\"><tbody><tr><td style=\" font-family: Poppins, Arial; color:#000000; background: #061721; padding: 50px\"> ​<table align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"width:100%; max-width:600px;\"><tbody><tr><td> <img src=\""+Tools.GetAppSetting("projectCdnURL") + "logo-white.png\" alt=\""+Tools.GetAppSetting("projectName")+ "\" width=\"180\"></td></tr><tr><td height=\"80\"></td></tr><tr><td style=\" font-family: Poppins, Arial; font-size: 18px; color:#ffffff;\"> <strong>{0}</strong></td></tr></tbody></table></td></tr><tr><td style=\" font-family: Poppins, Arial; color:#000000; padding: 50px\"><table align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"width:100%; max-width:600px;\"><tbody><tr><td style=\" font-family: Poppins, Arial; color:#000000; font-size: 12px;\"> {1}, <strong>{2}</strong> <br/><br/> {3}</td></tr></tbody></table></td></tr><tr><td style=\" font-family: Poppins, Arial; color:#000000; padding: 50px; background: #f5f5f5;\"><table align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"width:100%; max-width:600px;\"><tbody><tr><td style=\" font-family: Poppins, Arial; color:#000000; font-size: 12px;\"> {4}, <strong>" + Tools.GetAppSetting("companyName") + "</strong></td></tr><tr><td height=\"30\"></td></tr><tr><td style=\" font-family: Poppins, Arial; color:#000000; font-size: 12px;\"> {5} <a style=\"color:#000000; text-decoration: none\" href=\"" + Tools.GetAppSetting("projectOfficialMail") + "\"><strong>"+Tools.GetAppSetting("projectOfficialMail") + "</strong></a></td></tr><tr><td height=\"30\"></td></tr><tr><td style=\" font-family: Poppins, Arial; color:#000000; font-size: 12px;\"> <strong>{6}</strong></td></tr><tr><td style=\" font-family: Poppins, Arial; color:#000000; font-size: 12px;\"> <a style=\"padding: 10px; display: inline-block; cursor: pointer;\" href=\""+Tools.GetAppSetting("facebookURL") +"\" title=\"Facebook\"> <img src=\"" + Tools.GetAppSetting("projectCdnURL")+"facebook.png\" alt=\"\" height=\"30\"> </a> <a style=\"padding: 10px; display: inline-block; cursor: pointer;\" href=\""+ Tools.GetAppSetting("instagramURL") +"\" title=\"Instagram\"> <img src=\""+Tools.GetAppSetting("projectCdnURL")+ "instagram.png\" alt=\"\" height=\"30\"> </a></td></tr><tr><td height=\"30\"></td></tr><tr><td style=\" font-family: Poppins, Arial; color:#000000; font-size: 12px;\"> <strong>{7}</strong></td></tr><tr><td style=\" font-family: Poppins, Arial; color:#000000; font-size: 12px;\"> <a style=\"color:#000000; text-decoration: none\" href=\"" + Tools.GetAppSetting("projectWebSite")+"\" title=\""+Tools.GetAppSetting("projectName")+"\">"+Tools.GetAppSetting("projectWebSite")+"</a></td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table></body></html>";
    }
}
