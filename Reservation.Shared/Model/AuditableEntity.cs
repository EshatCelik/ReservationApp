﻿using System;

namespace Reservation.Shared.Model
{
    public abstract class AuditableEntity : IAuditableEntity
    {
        public bool IsDelete { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
    }
}