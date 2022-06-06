﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BootcampFinal.Data.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);


    }
}