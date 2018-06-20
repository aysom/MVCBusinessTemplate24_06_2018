﻿using _2018_SG_MVC_BTPROJECT.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _2018_SG_MVC_BTPROJECT.Infrastructure.Repository
{
    public interface IRepository<TEntity>
    {
        //birinci
        IList<TEntity> GetAll();
        IList<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
        TEntity Where2(Expression<Func<TEntity, bool>> predicate);
        TEntity Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        TEntity GetById(int id);
        Boolean GetByIdBool(int id);
        Boolean Any(Expression<Func<TEntity, bool>> lambda);

      



    }
}
