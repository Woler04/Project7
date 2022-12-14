
namespace Project7.Models
{
    public class TaskListModel
    {
        public int TaskListId { get; set; }
        public int UserId { get; set; }
        public string TaskListTitle { get; set; }
        public List<TaskModel> TaskList { get; set; }
    }
}
