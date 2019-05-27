using Hotel.DAO.HotelService;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DAO.HotelServiceImpl
{
    public class SendEmailServiceImpl : ISendEmailService
    {
        private readonly IConfiguration _configuration;
        public SendEmailServiceImpl(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task SendEmail(string email, string subject, string message)
        {
            using (var client = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = _configuration["EmailSettings:UsernameEmail"],
                    Password = _configuration["EmailSettings:UsernamePassword"]
                };

                client.Credentials = credential;
                client.Host = _configuration["EmailSettings:PrimaryDomain"];
                client.Port = int.Parse(_configuration["EmailSettings:PrimaryPort"]);
                client.EnableSsl = true;

                using (var emailMessage = new MailMessage())
                {
                    emailMessage.To.Add(new MailAddress(email));
                    emailMessage.From = new MailAddress(_configuration["EmailSettings:UsernameEmail"]);
                    emailMessage.Subject = subject;
                    emailMessage.Body = message;
                    client.Send(emailMessage);
                }
            }
            await Task.CompletedTask;
        }
    }
}
