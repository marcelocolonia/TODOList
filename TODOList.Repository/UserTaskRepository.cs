using System;
using System.Collections.Generic;
using System.Linq;
using TODOList.Core;
using TODOList.Repository.Interfaces;

namespace TODOList.Repository
{
    public class UserTaskRepository : IUserTaskRepository
    {
        public IQueryable<UserTask> List()
        {
            var userOne = new User()
            {
                Id = 100,
                FirstName = "Peter",
                LastName = "Parker",
            };

            var userTwo = new User()
            {
                Id = 200,
                FirstName = "Steve",
                LastName = "Rogers"
            };

            var userTasksStub = new List<UserTask>()
            {
                new UserTask()
                {
                    User = userOne,
                    Description = "Clean up the house",
                    LastUpdate = DateTime.UtcNow
                },
                new UserTask()
                {
                    User = userOne,
                    Description = "Buy groceries",
                    LastUpdate = DateTime.UtcNow
                },
                new UserTask()
                {
                    User = userTwo,
                    Description = "Walk the dog",
                    LastUpdate = DateTime.UtcNow
                }
            };

            return userTasksStub.AsQueryable();
        }
    }
}
