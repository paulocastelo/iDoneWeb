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
        [Required] // Not Null
        [StringLength(100)] // Max Length
        public string Title { get; set; }

        [StringLength(500)] // Max Length
        public string Description { get; set; }
        [Required] // Not Null
        public DateTime CreatedDate { get; set; }

        [Required] // Not Null
        public DateTime DueDate { get; set; }
        [Required] // Not Null
        public UserTaskStatus Status { get; set; }
    }
}
