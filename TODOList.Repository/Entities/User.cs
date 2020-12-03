using System.Collections.Generic;

namespace TODOList.Repository.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }

        public virtual IEnumerable<UserTask> Tasks { get; set; }
    }
}
