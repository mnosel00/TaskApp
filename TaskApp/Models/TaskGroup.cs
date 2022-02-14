namespace TaskApp.Models
{
    public class TaskGroup
    {
        public int Id { get; set; }
        public string NameOfTaskGroup { get; set; }
        public int Licznik { get; set; }
        public UserTask UserTask { get; set; }
    }
}
