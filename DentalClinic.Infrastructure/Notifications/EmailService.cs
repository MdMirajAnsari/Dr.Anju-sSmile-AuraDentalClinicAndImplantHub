using DentalClinic.API.DTOs.Notifications;
using DentalClinic.Application.Notifications;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.Infrastructure.Notifications
{
    public class EmailService : INotifications
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendAppointmentConfirmation(AppointmentConfirmationDTO appointmentConfirmation)
        {
            var subject = "Appointment Confirmation";
            var body = $"Dear {appointmentConfirmation.Patient},\n\n" +
                       $"Your appointment with Dr. {appointmentConfirmation.Dentist} at {appointmentConfirmation.DentalOffice} is confirmed for {appointmentConfirmation.Date:MMMM dd, yyyy 'at' hh:mm tt}.\n\n" +
                       "Thank you for choosing our dental clinic!";

            await SendEmail(appointmentConfirmation.Patient_Email, subject, body);
        }

        public async Task SendAppointmentReminder(AppointmentReminderDTO appointmentReminder)
        {
            var subject = "Appointment Reminder";
            var body = $"Dear {appointmentReminder.Patient},\n\n" +
                       $"This is a reminder for your upcoming appointment with Dr. {appointmentReminder.Dentist} at {appointmentReminder.DentalOffice} on {appointmentReminder.Date:MMMM dd, yyyy 'at' hh:mm tt}.\n\n" +
                       "Please arrive 10 minutes early and bring any necessary documents.\n\n" +
                       "Thank you for choosing our dental clinic!";

            await SendEmail(appointmentReminder.Patient_Email, subject, body);
           
        }

        public async Task SendEmail(string to, string subject, string body)
        {
           var from = _configuration.GetValue<string>("EMAIL_CONFIGURATIONS:EMAIL");
           var password = _configuration.GetValue<string>("EMAIL_CONFIGURATIONS:PASSWORD");
           var host = _configuration.GetValue<string>("EMAIL_CONFIGURATIONS:HOST");
           var port = _configuration.GetValue<int>("EMAIL_CONFIGURATIONS:PORT");

            var smptClient = new SmtpClient(host, port);
            smptClient.EnableSsl = true;
            smptClient.UseDefaultCredentials = false;
            smptClient.Credentials = new NetworkCredential(from, password);

            var mailMessage = new MailMessage(from!, to, subject, body);
            await smptClient.SendMailAsync(mailMessage);

        }
    }
}
