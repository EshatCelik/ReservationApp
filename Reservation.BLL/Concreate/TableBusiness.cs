using Reservation.BLL.Abstract;
using Reservation.Core.Entity;
using Reservation.Core.Repository.EntityFramework.DAL.Abstract;
using Reservation.Core.Repository.InMemory.Abstract;
using Reservation.Shared.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.BLL.Concreate
{
    public class TableBusiness : GenericBusiness<Table>,ITableBusiness
    {
        private readonly IInMemoryTableRepository _tableRepository;
        private readonly IInMemoryReservationRepository _reservationRepository;
        public TableBusiness(IInMemoryTableRepository tableRepository, IInMemoryReservationRepository reservationRepository):base(tableRepository) 
        {
            _tableRepository = tableRepository;
            _reservationRepository = reservationRepository;
        }

        public async Task<ResponseDto<List<Table>>> AvailableTables()
        {
            var reservationList=_reservationRepository.GetAll().Result.Select(x=>x.TableNumber).ToList();
            var tableList = await _tableRepository.GetAll();

            return ResponseDto<List<Table>>.Succes(tableList.Where(x=>x.Number!=reservationList.FirstOrDefault()).ToList(),200);
        }


        public async Task<ResponseDto<bool>> IsTableAvailable(int id)
        {
            if (_reservationRepository.GetAll().Result.FirstOrDefault(x => x.TableNumber == id) == null)
                return ResponseDto<bool>.Succes(200);
            return ResponseDto<bool>.Fail("Table is not avilable", 400, false);

        }
    }
}
