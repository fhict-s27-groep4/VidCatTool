﻿using Data_Layer.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data_Layer.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected IDBContext context;

        public Repository(IDBContext context)
        {
            this.context = context;
        }

        public int Count(Func<T, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public void Create(T entity)
        {
            throw new NotImplementedException(); 
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            throw new NotImplementedException();
        }
        
        public IEnumerable<T> GetAll()
        {
            return context.SelectQuery<T>();
        }

        public T GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
