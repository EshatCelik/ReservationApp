using AutoMapper;
using Reservation.Core.Entity;
using Reservation.Shared.Dto.Reservation;
using Reservation.Shared.Dto.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation.Core.Utilities
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Entity.Reservation, ReservationCreateDto>().ReverseMap();
            CreateMap<Table, TableCreateDto>().ReverseMap();
        }
    }
}
