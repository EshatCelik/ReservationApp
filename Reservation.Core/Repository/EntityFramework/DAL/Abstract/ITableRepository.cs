using Reservation.Core.Entity;
using Reservation.Core.Repository.DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation.Core.Repository.EntityFramework.DAL.Abstract
{
    public interface ITableRepository : IGenericRepository<Table>
    {
    }
}
