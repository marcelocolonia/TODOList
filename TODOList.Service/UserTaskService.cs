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
        //  NOTE: our methods are async. 
        //  In a real world app we would have to deal with async stuff (EF ListAsync for instance)
        //  but for test purposes our methods simply return Task.FromResult

        private readonly IUserTaskRepository _userTaskRepository;
        private readonly IUserRepository _userRepository;

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

        public Task<IEnumerable<UserTask>> GetUserTasks(int userId)
        {
            return Task.FromResult(_userTaskRepository.List().Where(userTask => userTask.User.Id == userId).AsEnumerable());
        }

        public Task<User> GetUserById(int id)
        {
            return Task.FromResult(_userRepository.Get(id));
        }

        public Task DeleteUserTask(int userId, int[] userTaskIds)
        {
            var userTasksQuery = _userTaskRepository.List()
                //  Filtering our query by user id to make sure those tasks really belong to them
                .Where(x => x.User.Id == userId && userTaskIds.Contains(x.Id));

            foreach (var userTask in userTasksQuery.ToList())
            {
                _userTaskRepository.Delete(userTask.Id);
            }

            return Task.FromResult(true);
        }

        public Task<User> GetUserByCredentials(string userName, string password)
        {
            var user = _userRepository.List().SingleOrDefault(x => x.UserName == userName && x.Password == password);

            return Task.FromResult(user);
        }
    }
}
