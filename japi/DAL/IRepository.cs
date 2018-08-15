using System.Collections.Generic;

namespace JApi.DAL
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Get();
        T Get(string id);
        void Add(T entity);        
        void Delete(string id);
        void Update(string id, T entity);
    }
}