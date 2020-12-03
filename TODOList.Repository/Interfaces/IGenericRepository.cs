using System.Linq;

namespace TODOList.Repository.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        public IQueryable<T> List();
        int Create(T item);
        T Get(int id);
        bool Delete(int id);
    }
}
