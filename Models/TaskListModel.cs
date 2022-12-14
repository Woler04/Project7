
using System.ComponentModel.DataAnnotations;

namespace Project7.Models
{
    public class TaskListModel
    {
        [Key]
        public int TaskListId { get; set; }
        public int UserId { get; set; }
        public string TaskListTitle { get; set; }
        public List<TaskModel> TaskList { get; set; }
    }
}
