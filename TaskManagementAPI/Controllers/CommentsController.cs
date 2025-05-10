using Microsoft.AspNetCore.Mvc;
using TaskManagementAPI.Data;
using TaskManagementAPI.Model;

namespace TaskManagementAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CommentsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddComment([FromBody] TaskComment comment)
        {
            if (comment == null || string.IsNullOrWhiteSpace(comment.Content))
            {
                return BadRequest("Comment content cannot be empty.");
            }

            // Save the comment to the database
            _context.TaskComments.Add(comment);
            _context.SaveChanges();

            return Ok(comment);
        }

        [HttpGet("task/{taskId}")]
        public IActionResult GetComments(int taskId)
        {
            var comments = _context.TaskComments
                .Where(c => c.TaskId == taskId)
                .ToList();

            if (comments == null || !comments.Any())
            {
                return NotFound("No comments found for this task.");
            }

            return Ok(comments);
        }
    }
}
