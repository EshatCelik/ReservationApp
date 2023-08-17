using Reservation.Shared.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation.Core.Entity
{
    public class Table : AuditableEntity, IEntity
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int Capacity { get; set; }
    }
}
