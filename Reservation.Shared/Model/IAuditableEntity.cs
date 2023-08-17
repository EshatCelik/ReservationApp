using System;

namespace Reservation.Shared.Model
{
    public interface IAuditableEntity
    {
        bool IsDelete { get; set; }
        DateTime CreatedOn { get; set; }
        string CreatedBy { get; set; }
        DateTime UpdatedOn { get; set; }
        string UpdatedBy { get; set; }
    }
}