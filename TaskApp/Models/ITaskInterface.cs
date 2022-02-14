using System.Collections.Generic;

namespace TaskApp.Models
{
    public interface ITaskInterface
    {
        TaskGroup GetTaskGroup(int id);
        UserTask GetUserTask(int id);
        List<TaskGroup> GetAllTaskGroups();
        TaskGroup Add(TaskGroup taskGroup);
        UserTask Add(UserTask userTask);
        TaskGroup Update(TaskGroup taskGroup);
        UserTask Update(UserTask userTask);
        List<UserCollection> GetAllUsers();
        void Delete(int id);
        
        List<UserTask> GetAllUserTask();
        UserCollection GetUser(int id);
        UserCollection Add(UserCollection user);
        UserCollection Update(UserCollection user);
        
    }
}
