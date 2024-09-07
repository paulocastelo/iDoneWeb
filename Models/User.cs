using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace iDoneWeb.Models
{
    public class User
    {
        [Key] // Primary Key
        public int Id { get; set; }
        [Required] // Not Null
        [StringLength(100)] // Max Length
        public required string Name { get; set; }
        [Required] // Not Null
        [StringLength(100)] // Max Length
        public required string Email { get; set; }
        [Required] // Not Null
        [StringLength(50)] // Max Length
        public required string Password { get; set; }
        public required ICollection<UserTask> UserTasks { get; set; }
    }
}
