using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskApp.Models
{
    public class UserTask
    {
        public int Id { get; set; }
        [Required]
        public string NameOfUserTask { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Deadline { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public UserCollection UserCollection { get; set; }

        public Status Status { get; set; }

        public int TaskGroupId { get; set; }

        [ForeignKey("TaskGroupId")]
        public TaskGroup TaskGroup { get; set; }

        

    }
}
