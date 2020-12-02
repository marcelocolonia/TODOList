using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TODOList.Core;
using TODOList.Repository.Interfaces;
using TODOList.Service.Interfaces;

namespace TODOList.Service
{
    public class UserTaskService : IUserTaskService
    {
        private IUserTaskRepository _userTaskRepository;

        public UserTaskService(IUserTaskRepository userTaskRepository)
        {
            _userTaskRepository = userTaskRepository;
        }

        public Task<IEnumerable<UserTask>> GetUserTasks(User user)
        {
            return Task.FromResult(_userTaskRepository.List().Where(userTask => userTask.User.Id == user.Id).AsEnumerable());
        }
    }
}
