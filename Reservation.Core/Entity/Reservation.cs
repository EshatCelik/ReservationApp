using Reservation.Shared.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation.Core.Entity
{
    public class Reservation :AuditableEntity, IEntity
    {
        public int Id { get; set; }
        public string ReservationName { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public DateTime ReservationDate { get; set; }
        public int NumberOfGuests { get; set; }
        public int TableNumber { get; set; }
    }
}
