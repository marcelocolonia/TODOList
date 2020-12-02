using System.Collections.Generic;
using System.Threading.Tasks;
using TODOList.Core;

namespace TODOList.Service.Interfaces
{
    public interface IUserTaskService
    {
        Task<IEnumerable<UserTask>> GetUserTasks(User user);
    }
}