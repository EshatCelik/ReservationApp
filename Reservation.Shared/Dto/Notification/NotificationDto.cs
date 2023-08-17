using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation.Shared.Dto.Notification
{
    public class NotificationDto
    {
        public int CorrelationId { get; set; }
        public string Source { get; set; }
        public string Message { get; set; }
    }
}
