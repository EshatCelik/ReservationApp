using Reservation.Core.Repository.DAL.Concreate;
using Reservation.Core.Repository.EntityFramework.DAL.Abstract;
using Reservation.Core.Repository.EntityFramework.DAL.Concreate;
using Reservation.Core.Repository.InMemory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation.Core.Repository.EntityFramework.DAL.Concreate
{
    public class ReservationRepository : GenericRepository<Entity.Reservation, ReservationDBContext>, IReservationRepository
    {
    }
}
