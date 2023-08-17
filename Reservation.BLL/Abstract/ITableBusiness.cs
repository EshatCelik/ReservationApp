using Reservation.Core.Entity;
using Reservation.Shared.Dto.Response;
using Reservation.Shared.Dto.Table;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.BLL.Abstract
{
    public interface ITableBusiness:IGenericBusiness<Table>
    {
        Task<ResponseDto<bool>> IsTableAvailable(int  id);
        Task<ResponseDto<List<Table>>> AvailableTables();
    }
}
