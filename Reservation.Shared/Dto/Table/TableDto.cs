using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation.Shared.Dto.Table
{
    public class TableDto : IDto
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int Capacity { get; set; }
    }
}
