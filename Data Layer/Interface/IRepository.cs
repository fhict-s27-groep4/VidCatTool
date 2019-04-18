using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.Interface
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        Task<T> GetByID(int id);

        void Create(T entity);

        void Update(T entity);

        void Delete(T entity);

        Task<int> Count();
    }
}
