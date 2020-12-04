using System.ComponentModel.DataAnnotations;

namespace TODOList.ViewModels
{
    public class NewUserTaskViewModel
    {
        [Required]
        [MaxLength(50)]
        public string Description { get; set; }
    }
}
