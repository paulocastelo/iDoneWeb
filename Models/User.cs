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
        public string Name { get; set; }
        [Required] // Not Null
        [StringLength(100)] // Max Length
        public string Email { get; set; }
        [Required] // Not Null
        [StringLength(50)] // Max Length
        public string Password { get; set; }
        public ICollection<UserTask> Tasks { get; set; }
    }
}
