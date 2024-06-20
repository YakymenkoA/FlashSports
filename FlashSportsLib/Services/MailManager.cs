using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace FlashSportsLib.Services
{
    public class MailManager
    {
        private int _port = 2525;
        private string _host = "sandbox.smtp.mailtrap.io";
        private SmtpClient _smtp;

        public MailManager()
        {
            _smtp = new SmtpClient(_host, _port);
        }

        public void SendMail(string email, string chatLog)
        {
            MailAddress from = new MailAddress("FlashSports@fs.app");
            MailAddress to = new MailAddress(email);

            MailMessage mm = new MailMessage(from, to);
            mm.Subject = "Thank you for contacting our support!";
            mm.Body = $"Here is a history of your messages\n{chatLog}";

            _smtp.Credentials = new NetworkCredential("c34e8ee702b02b", "1478667915aea8");
            _smtp.EnableSsl = true;
            _smtp.Send(mm);
        }
    }
}
