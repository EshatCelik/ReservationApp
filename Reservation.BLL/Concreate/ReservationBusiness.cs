using Reservation.BLL.Abstract;
using Reservation.Core.Repository.DAL.Abstract;
using Reservation.Core.Repository.EntityFramework.DAL.Abstract;
using Reservation.Core.Repository.InMemory.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation.BLL.Concreate
{
    public class ReservationBusiness : GenericBusiness<Core.Entity.Reservation>, IReservationBusiness
    {
        public ReservationBusiness(IInMemoryReservationRepository reservationRepository) : base(reservationRepository)
        {
        }
    }
}
