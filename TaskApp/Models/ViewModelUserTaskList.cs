using System.Collections.Generic;

namespace TaskApp.Models
{
    public class ViewModelUserTaskList
    {
        public int TaskGroupId { get; set; }
        public List<UserTask> UserTasksList { get; set; }
    }
}
