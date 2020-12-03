using System;

namespace TODOList.ViewModels
{
    public class UserTaskViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
