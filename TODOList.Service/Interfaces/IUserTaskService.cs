using System.Collections.Generic;
using System.Threading.Tasks;
using TODOList.Repository.Entities;

namespace TODOList.Service.Interfaces
{
    public interface IUserTaskService
    {
        Task<IEnumerable<UserTask>> GetUserTasks(int userId);
        Task<int> CreateUserTask(User user, string description);
        Task<User> GetUserById(int id);
        Task DeleteUserTask(int userId, int[] userTaskIds);
        Task<User> GetUserByCredentials(string userName, string password);
    }
}