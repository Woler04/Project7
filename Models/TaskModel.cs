using System.ComponentModel.DataAnnotations;

namespace Project7.Models
{
    public class TaskModel
    {
        [Key]
        public int TaskId { get; set; }
        public int TaskListId { get; set; }
        public int UserId { get; set; }
        public string TaskTitle { get; set; }
        [DataType(DataType.Date)]
        public DateTime TaskDeadline { get; set; }
        public string TaskDesc { get; set; }
    }
}
