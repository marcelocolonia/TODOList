using System;

namespace TODOList.Core
{
    public class UserTask
    {
        public User User { get; set; }
        public string Description { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
