using System.Collections.Generic;
using TODOList.Repository.Entities;
using TODOList.Repository.Interfaces;

namespace TODOList.Repository
{
    public class DbContext : IDbContext
    {
        public List<User> Users { get; set; }
        public List<UserTask> UserTasks { get; set; }

        public DbContext()
        {
            Users = new List<User>()
            {
                new User()
                {
                    Id = 100,
                    FirstName = "User",
                    LastName = "Test",
                    UserName = "test",
                    Password = "pwd123",
                    Tasks = new List<UserTask>()
                }
            };

            UserTasks = new List<UserTask>();
        }
    }
}
