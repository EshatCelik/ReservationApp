using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation.Shared.Dto.Reservation
{
    public class ReservationCreateDto : IDto
    {
        public int Id { get; set; }
        public string ReservationName { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public DateTime ReservationDate { get; set; } = DateTime.Now;
        public int NumberOfGuests { get; set; }
        public int TableNumber { get; set; }
    }
}
