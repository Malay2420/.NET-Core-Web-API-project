using System.ComponentModel.DataAnnotations;

namespace TaskManagementAPI.DTOs
{
    public class TaskCreateDto
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? DueDate { get; set; }

        public int? AssignedToId { get; set; } // User Id
    }
}
