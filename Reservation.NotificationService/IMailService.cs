using Reservation.Shared.Dto.Notification;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation.NotificationService
{
    public interface IMailService
    {
        bool SendMail(NotificationDto message);
    }
}
