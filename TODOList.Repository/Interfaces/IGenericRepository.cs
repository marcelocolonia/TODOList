using System.Linq;

namespace TODOList.Repository.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        public IQueryable<T> List();
        int Create(T item);
        T Get(int id);

        //IQueryable<T> List();

        //bool Delete(int id);

        //bool SaveChanges();
    }
}
