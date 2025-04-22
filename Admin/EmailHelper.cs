using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Net;
using System.Web;

public static class EmailHelper
{
    public static void SendEmail(string to, string subject, string body, List<HttpPostedFile> attachments = null)
    {
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress("adityaalt218@gmail.com");
        mail.To.Add(to);
        mail.Subject = subject;
        mail.Body = body;

        if (attachments != null)
        {
            foreach (HttpPostedFile file in attachments)
            {
                if (file != null && file.ContentLength > 0)
                {
                    string filename = Path.GetFileName(file.FileName);
                    mail.Attachments.Add(new Attachment(file.InputStream, filename));
                }
            }
        }

        SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
        smtp.Credentials = new NetworkCredential("adityaalt218@gmail.com", "gbqxshitgwjhenwm");
        smtp.EnableSsl = true;
        smtp.Send(mail);
    }
}
