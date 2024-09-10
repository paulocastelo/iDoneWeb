using System;
using iDoneWeb.Models;
using iDoneWeb.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace iDoneWeb.Models
{
    public class UserTask
    {
        [Key] // Primary Key
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} required!")] // Not Null
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} size should be between {2} and {1}!")] // Max Length
        public required string Title { get; set; }

        [StringLength(500)] // Max Length
        public required string Description { get; set; }
        [Required] // Not Null
        public DateTime CreatedDate { get; set; }

        [Required] // Not Null
        public DateTime DueDate { get; set; }
        [Required] // Not Null
        public UserTaskStatusEnum Status { get; set; }
    }
}
