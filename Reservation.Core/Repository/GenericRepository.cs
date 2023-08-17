using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Reservation.Core.Repository.DAL.Abstract;
using Reservation.Core.Repository.EntityFramework;
using Reservation.Core.Repository.EntityFramework.DAL.Abstract;
using Reservation.Core.Repository.InMemory;
using Reservation.Shared.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Core.Repository.DAL.Concreate
{
    public class GenericRepository<TEntity, TContext> : IGenericRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext, new()
    {
       
        //private readonly ReservationDBContext _context;
        //public GenericRepository(ReservationDBContext context)
        //{
        //    _context = context;
        //}




        public virtual async Task<TEntity> Create(TEntity entity)
        {
            using (TContext db = new TContext())
            {
                var add = db.Entry(entity);
                add.State = EntityState.Added;
                db.SaveChanges();

            }
            return entity;
            //_context.Set<TEntity>().Add(entity);
            //await _context.SaveChangesAsync();
            //return entity;
        }

        public virtual async Task<TEntity> Delete(int id)
        {
            TEntity entity = null;

            using (TContext db = new TContext())
            {
                var delete = db.Entry(id);

                entity = db.Find<TEntity>(id);
                delete.State = EntityState.Deleted;
                db.SaveChanges();

            }
            return entity;

            //TEntity entity = null;
            //try
            //{
            //    entity = await _context.Set<TEntity>().FirstAsync();
            //    _context.Set<TEntity>().Remove(entity);
            //    await _context.SaveChangesAsync();
            //    return entity;

            //}
            //catch (Exception)
            //{
            //}
            //return entity;
        }

        public virtual async Task<TEntity> Get(int id)
        {
            TEntity entity = null;
            using (TContext db = new TContext())
            {
                entity = await db.FindAsync<TEntity>(id);
            }
            return entity;
            //return await _context.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            List<TEntity> entities = null;
            using (TContext db = new TContext())
            {
                entities = await db.Set<TEntity>().ToListAsync();
            }
            return entities;
            //return await _context.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<TEntity> Update(TEntity entity)
        {
            using (TContext db = new TContext())
            {
                var update = db.Entry(entity);
                update.State = EntityState.Modified;
                db.SaveChanges();

            }
            return entity;

            //_context.Set<TEntity>().Update(entity);
            //await _context.SaveChangesAsync();
            //return entity;
        }
    }
}
