using System.Linq;
using TODOList.Repository.Entities;
using TODOList.Repository.Interfaces;

namespace TODOList.Repository
{
    public class UserTaskRepository : IUserTaskRepository
    {
        private readonly IDbContext _dbContext;

        public UserTaskRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(UserTask userTask)
        {
            var maxUserTaskId = _dbContext.UserTasks.Select(x => x.Id).DefaultIfEmpty(0).Max();

            userTask.Id = maxUserTaskId  + 1;

            _dbContext.UserTasks.Add(userTask);

            return userTask.Id;
        }

        public UserTask Get(int id)
        {
            return _dbContext.UserTasks.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<UserTask> List()
        {
            return _dbContext.UserTasks.AsQueryable();
        }
    }
}
