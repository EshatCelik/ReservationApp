using Reservation.Core.Entity;
using Reservation.Core.Repository.DAL.Concreate;
using Reservation.Core.Repository.EntityFramework.DAL.Abstract;
using Reservation.Core.Repository.EntityFramework.DAL.Concreate;
using Reservation.Core.Repository.InMemory;
using Reservation.Core.Repository.InMemory.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation.Core.Repository.InMemory.Concreate
{
    public class InMemoryTableRepository : GenericRepository<Table, InMemoryDBContext>, IInMemoryTableRepository
    {
       
    }
}
