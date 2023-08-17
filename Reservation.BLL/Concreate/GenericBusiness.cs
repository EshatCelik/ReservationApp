using Reservation.BLL.Abstract;
using Reservation.Core.Repository.DAL.Abstract;
using Reservation.Core.Repository.EntityFramework.DAL.Abstract;
using Reservation.Shared.Dto.Response;
using Reservation.Shared.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.BLL.Concreate
{
    public class GenericBusiness<TEntity> : IGenericBusiness<TEntity> where TEntity : class, IEntity
    {
        private readonly IGenericRepository<TEntity> _genericRepository;

        public GenericBusiness(IGenericRepository<TEntity> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public virtual async Task<ResponseDto<TEntity>> Create(TEntity entity)
        {
            return ResponseDto<TEntity>.Succes(await _genericRepository.Create(entity), 200);
        }

        public virtual async Task<ResponseDto<TEntity>> Delete(int id)
        {
            return ResponseDto<TEntity>.Succes(await _genericRepository.Delete(id), 200);
        }

        public virtual async Task<ResponseDto<TEntity>> Get(int id)
        {
            return ResponseDto<TEntity>.Succes(await _genericRepository.Get(id), 200);
        }

        public virtual async Task<ResponseDto<List<TEntity>>> GetAll()
        {
            return ResponseDto<List<TEntity>>.Succes(await _genericRepository.GetAll(), 200);
        }

        public virtual async Task<ResponseDto<TEntity>> Update(TEntity entity)
        {
            return ResponseDto<TEntity>.Succes(await _genericRepository.Update(entity), 200);
        }
    }
}
