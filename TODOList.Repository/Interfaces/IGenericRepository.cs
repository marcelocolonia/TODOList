using System.Linq;

namespace TODOList.Repository.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        public IQueryable<T> List();

        //IQueryable<T> List();
        //bool Create(T item);
        //bool Delete(int id);
        //T Get(int id);
        //bool SaveChanges();
    }
}
