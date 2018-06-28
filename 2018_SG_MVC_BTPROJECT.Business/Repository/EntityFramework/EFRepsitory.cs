using _2018_SG_MVC_BTPROJECT.Entities;
using _2018_SG_MVC_BTPROJECT.Entities.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _2018_SG_MVC_BTPROJECT.Business.Repository.EntityFramework
{
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {

        private BTContext _context;
        public BTContext Context { get => _context; set => _context = value; }

        public EFRepository(BTContext context)
        {
            _context = context;
        }

        public IList<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public IList<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            var result = _context.Set<TEntity>().Where(predicate);
            return result.ToList();
        }

        public TEntity Insert(TEntity entity)
        {
            var result = _context.Set<TEntity>().Add(entity);
            return result;
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        { 
            //_context.Set<TEntity>().Remove(entity);
           // _context.Entry(entity).State = EntityState.Modified; 
            var dbEntityEntry = _context.Entry<TEntity>(entity);
            dbEntityEntry.State = EntityState.Deleted; 
        }
         

        public TEntity GetById(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }


        public bool GetByIdBool(int id)
        {
            if (id == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public TEntity Where2(Expression<Func<TEntity, bool>> predicate)
        {
            var result = _context.Set<TEntity>().Where(predicate);
            return result.Single();
        }

        public bool Any(Expression<Func<TEntity, bool>> lambda)
        {
            return _context.Set<TEntity>().Where(x => x.IsDeleted == false).Any(lambda);
        }

        public int SaveChanges()
        {
               int a = _context.SaveChanges();
                return a; 
        }

        public void Delete(object id)
        {
            TEntity entityToDelete = _context.Set<TEntity>().Find(id);
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _context.Set<TEntity>().Attach(entityToDelete);
            }
            _context.Set<TEntity>().Remove(entityToDelete);
        }
    }

}
