using Reservation.Core.Entity;
using Reservation.Core.Repository.DAL.Concreate;
using Reservation.Core.Repository.EntityFramework.DAL.Abstract;
using Reservation.Core.Repository.EntityFramework.DAL.Concreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation.Core.Repository.EntityFramework.DAL.Concreate
{
    public class TableRepository : GenericRepository<Table, ReservationDBContext>, ITableRepository
    {
    }
}
