using System.Collections.Generic;
using System.Linq;
using TODOList.Core;
using TODOList.Repository.Interfaces;

namespace TODOList.Repository
{
    public class UserTaskRepository : IGenericRepository<UserTask>
    {
        public IQueryable<UserTask> List()
        {
            return new List<UserTask>().AsQueryable();
        }
    }
}
