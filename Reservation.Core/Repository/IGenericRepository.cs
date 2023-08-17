using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Core.Repository.DAL.Abstract
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
        Task<T> Create(T entity);
    }
}
