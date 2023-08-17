using Reservation.Shared.Dto.Notification;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation.NotificationService
{
    public class MailService : IMailService
    {

        public bool SendMail(NotificationDto message)
        {

            //Mail gönderme işlemleri burda yapılacaktır

            message.Message = "Mail has already been sent !!!";

            CreateMailTemplate("setting", "body", "subject", "to");
            return true;
        }


        private string CreateMailTemplate(object mailSetting, string body, string subject, string to = null)
        {
            //notification ayarları burda yapılır !!!

            return string.Empty;

        }
    }
}
