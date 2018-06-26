using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2018_SG_MVC_BTPROJECT.Business.Repository;
using _2018_SG_MVC_BTPROJECT.Business.Repository.EntityFramework;
using _2018_SG_MVC_BTPROJECT.Entities;
using _2018_SG_MVC_BTPROJECT.Entities.Context;

namespace _2018_SG_MVC_BTPROJECT.Business.UnitOfWork
{
    public class UnitOfWork:IUnitOfWork
    {
        private BTContext _context;
        public BTContext Context { get => _context; set => _context = value; }

        public UnitOfWork()
        {
            _context = new BTContext();
        }
        
        private Dictionary<Type, object> repositories = new Dictionary<Type, object>();
        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity
        {
            if (repositories.Keys.Contains(typeof(TEntity)) == true)
            {
                return repositories[typeof(TEntity)] as IRepository<TEntity>;
            }
            IRepository<TEntity> repository = new EFRepository<TEntity>(_context);
            repositories.Add(typeof(TEntity), repository);
            return repository; 
        }

        public int SaveChanges()
        {
            var result = _context.SaveChanges();
            return result;
        }

        

    }
}
