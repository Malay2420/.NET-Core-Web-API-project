using System.ComponentModel.DataAnnotations;

namespace TaskManagementAPI.Model
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; } // In real apps → hash this!

        [Required]
        public UserRole Role { get; set; }

        public ICollection<TaskItem> Tasks { get; set; } // Tasks assigned
        public ICollection<TaskComment> Comments { get; set; } // Comments made
    }
}
