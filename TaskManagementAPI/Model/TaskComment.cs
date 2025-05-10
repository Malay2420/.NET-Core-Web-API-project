using System.ComponentModel.DataAnnotations;

namespace TaskManagementAPI.Model
{
    public class TaskComment
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // FK: Task
        public int TaskId { get; set; }
        public TaskItem Task { get; set; }

        // FK: User
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
