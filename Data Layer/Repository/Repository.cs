using Data_Layer.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly VidCatToolContext _context;

        public Repository(VidCatToolContext context)
        {
            _context = context;
        }

        protected async void Save() => await _context.SaveChangesAsync();

        public async Task<int> Count()
        {
            return await _context.Set<T>().CountAsync();
        }

        public void Create(T entity)
        {
            _context.Add(entity);
            Save();
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
            Save();
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public async Task<T> GetByID(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            Save();
        }
    }
}
