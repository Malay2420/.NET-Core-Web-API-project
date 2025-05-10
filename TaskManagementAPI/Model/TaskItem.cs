using System.ComponentModel.DataAnnotations;

namespace TaskManagementAPI.Model
{
    public class TaskItem
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? DueDate { get; set; }

        // FK: Assigned user
        public int? AssignedToId { get; set; }
        public User AssignedTo { get; set; }

        public ICollection<TaskComment> Comments { get; set; }
    }
}
