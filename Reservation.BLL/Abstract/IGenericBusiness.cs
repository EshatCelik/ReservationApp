using Reservation.Shared.Dto;
using Reservation.Shared.Dto.Response;
using Reservation.Shared.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.BLL.Abstract
{
    public interface IGenericBusiness<TEntity> where TEntity : class,IEntity
    {
        Task<ResponseDto<List<TEntity>>> GetAll();
        Task<ResponseDto<TEntity>> Get(int id);
        Task<ResponseDto<TEntity>> Update(TEntity entity);
        Task<ResponseDto<TEntity>> Delete(int id);
        Task<ResponseDto<TEntity>> Create(TEntity entity);
    }
}
