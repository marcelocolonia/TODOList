using System.Collections.Generic;
using System.Threading.Tasks;
using TODOList.Repository.Entities;

namespace TODOList.Service.Interfaces
{
    public interface IUserTaskService
    {
        Task<IEnumerable<UserTask>> GetUserTasks(User user);
        Task<int> CreateUserTask(User user, string description);
        Task<User> GetUserById(int id);
        Task DeleteUserTask(int userId, int[] userTaskIds);
    }
}