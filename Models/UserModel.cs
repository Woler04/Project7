namespace Project7.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string FirsstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public List<TaskListModel> TasksList { get; set; }

    }
}
