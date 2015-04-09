using System;
using System.Net.Mail;
using Experion.FileManager.Services.Dto;

namespace Experion.FileManager.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Security;
    using System.Reflection;
    using System.Security.Cryptography.X509Certificates;
    using System.Web.UI.HtmlControls;

    public class MailService
    {
        //public bool SendMail()
        //{
        //    try
        //    {
        //        var mail = new MailMessage();
        //        var smtpServer = new SmtpClient("smtp.gmail.com");

        //        mail.From = new MailAddress("codeno47@gmail.com");
        //        mail.To.Add("codeno47@gmail.com");
        //        mail.Subject = "Test Mail";
        //        mail.Body = "Report";
        //        //var attachment = new Attachment(filename);
        //        //mail.Attachments.Add(attachment);

        //        smtpServer.Port = 25;
        //        smtpServer.Credentials = new System.Net.NetworkCredential("codeno47", "rdhaf0mw@#");
        //        smtpServer.EnableSsl = true;

        //        smtpServer.Send(mail);
        //    }
        //    catch (Exception e)
        //    {
        //        return false;
        //    }

        //    return true;
        //}

        public bool SendMail(MailInfo mailInfo)
        {
            try
            {
                var mail = new MailMessage();
                var smtpServer = new SmtpClient(mailInfo.MailServer);

                mail.From = new MailAddress(mailInfo.FromEmail);
                foreach (var address in mailInfo.ToAddress)
                {
                    mail.To.Add(address);
                }

                foreach (var address in mailInfo.CcAddress)
                {
                    mail.CC.Add(address);
                }

                foreach (var address in mailInfo.BccAddress)
                {
                    mail.Bcc.Add(address);
                }
                
                mail.Subject = mailInfo.Subject;
                mail.Body = mailInfo.Body;
                if (!string.IsNullOrEmpty(mailInfo.AttachmentFile))
                {
                    var attachment = new Attachment(mailInfo.AttachmentFile);
                    mail.Attachments.Add(attachment);
                }
              

                smtpServer.Port = mailInfo.Port;
                smtpServer.Credentials = new System.Net.NetworkCredential(mailInfo.UserName, mailInfo.Password);
                smtpServer.EnableSsl = mailInfo.IsSslEnabled;

                ServicePointManager.ServerCertificateValidationCallback = delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };

                smtpServer.Send(mail);
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public HtmlTable BuildTable<T>(List<T> Data)
        {
            HtmlTable ht = new HtmlTable();
            //Get the columns
            HtmlTableRow htColumnsRow = new HtmlTableRow();
            typeof(T).GetProperties().Select(prop =>
            {
                HtmlTableCell htCell = new HtmlTableCell();
                htCell.InnerText = prop.Name;
                return htCell;
            }).ToList().ForEach(cell => htColumnsRow.Cells.Add(cell));
            ht.Rows.Add(htColumnsRow);
            //Get the remaining rows
            Data.ForEach(delegate(T obj)
            {
                HtmlTableRow htRow = new HtmlTableRow();
                obj.GetType().GetProperties().ToList().ForEach(delegate(PropertyInfo prop)
                {
                    HtmlTableCell htCell = new HtmlTableCell();
                    htCell.InnerText = prop.GetValue(obj, null).ToString();
                    htRow.Cells.Add(htCell);
                });
                ht.Rows.Add(htRow);
            });
            return ht;
        }
    }
}
