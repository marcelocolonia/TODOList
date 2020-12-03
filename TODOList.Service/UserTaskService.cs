using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TODOList.Repository.Entities;
using TODOList.Repository.Interfaces;
using TODOList.Service.Interfaces;

namespace TODOList.Service
{
    public class UserTaskService : IUserTaskService
    {
        private IUserTaskRepository _userTaskRepository;
        private IUserRepository _userRepository;

        public UserTaskService(
            IUserTaskRepository userTaskRepository,
            IUserRepository userRepository
            )
        {
            _userTaskRepository = userTaskRepository;
            _userRepository = userRepository;
        }

        public Task<int> CreateUserTask(User user, string description)
        {
            var newTaskId = _userTaskRepository.Create(new UserTask()
            {
                Description = description,
                LastUpdate = DateTime.UtcNow,
                User = user
            });

            return Task.FromResult(newTaskId);
        }

        public Task<IEnumerable<UserTask>> GetUserTasks(User user)
        {
            return Task.FromResult(_userTaskRepository.List().Where(userTask => userTask.User.Id == user.Id).AsEnumerable());
        }

        public Task<User> GetUserById(int id)
        {
            return Task.FromResult(_userRepository.Get(id));
        }
    }
}
