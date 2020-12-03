using System.Collections.Generic;
using TODOList.Repository.Entities;

namespace TODOList.Repository.Interfaces
{
    public interface IDbContext
    {
        List<User> Users { get; set; }
        List<UserTask> UserTasks { get; set; }
    }
}