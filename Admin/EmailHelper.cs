using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Net;
using System.Web;

public static class EmailHelper
{
    public static void SendEmail(string to, string subject, string body, string attachmentPath = null)
    {
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress("adityaalt218@gmail.com");
        mail.To.Add(to);
        mail.Subject = subject;
        mail.Body = body;

        if (!string.IsNullOrEmpty(attachmentPath))
        {
            if (File.Exists(attachmentPath))
            {
                string filename = Path.GetFileName(attachmentPath);
                mail.Attachments.Add(new Attachment(attachmentPath));
            }
        }

        SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
        smtp.Credentials = new NetworkCredential("adityaalt218@gmail.com", "gbqxshitgwjhenwm");
        smtp.EnableSsl = true;
        smtp.Send(mail);
    }

}
