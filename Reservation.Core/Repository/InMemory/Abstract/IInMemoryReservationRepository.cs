using Reservation.Core.Repository.DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation.Core.Repository.InMemory.Abstract
{
    public interface IInMemoryReservationRepository:IGenericRepository<Entity.Reservation>
    {
    }
}
