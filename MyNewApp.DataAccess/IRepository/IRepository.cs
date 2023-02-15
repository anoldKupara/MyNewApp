using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNewApp.DataAccess.IRepository
{
    public interface IRepository<T> where T : class
    {
        T GetFirstOrDefault(Expression<Func<T, bool>> filter);
        T Get(int id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Remove(int id);
        void Remove(T entity);
    }
}
