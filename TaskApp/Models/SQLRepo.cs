using System.Collections.Generic;
using System.Linq;

namespace TaskApp.Models
{
    public class SQLRepo : ITaskInterface
    {
        private MyAppDbContext _context;

        public SQLRepo(MyAppDbContext context)
        {
            _context = context;
        }
        public TaskGroup Add(TaskGroup taskGroup)
        {
            _context.TaskGroups.Add(taskGroup);
            _context.SaveChanges();
            return taskGroup;
        }

        public UserTask Add(UserTask userTask)
        {
            _context.UserTasks.Add(userTask);
            _context.SaveChanges();
            return userTask;
        }

        public UserCollection Add(UserCollection user)
        {
            _context.UserCollections.Add(user);
            _context.SaveChanges();
            return user;
        }

        public void Delete(int id)
        {
            TaskGroup taskGroup = _context.TaskGroups.Find(id);
            UserTask userTask =_context.UserTasks.Find(id);
            UserCollection userCollection = _context.UserCollections.Find(id);

            if (taskGroup != null)
            {
                _context.TaskGroups.Remove(taskGroup);
                _context.SaveChanges();
            }
            if (userTask != null)
            {
                _context.UserTasks.Remove(userTask);
                _context.SaveChanges();
            }
            if (userCollection != null)
            {
                _context.UserCollections.Remove(userCollection);
                _context.SaveChanges();
            }
        }

        public List<TaskGroup> GetAllTaskGroups()
        {
            return _context.TaskGroups.ToList();
        }

        public List<UserCollection> GetAllUsers()
        {
            return _context.UserCollections.ToList();
        }

        public List<UserTask> GetAllUserTask()
        {
            return _context.UserTasks.ToList();
        }

        public TaskGroup GetTaskGroup(int id)
        {
            return _context.TaskGroups.Find(id);
        }

        public UserCollection GetUser(int id)
        {
            return _context.UserCollections.Find(id);
        }

        public UserTask GetUserTask(int id)
        {
            return _context.UserTasks.Find(id);
        }

        public TaskGroup Update(TaskGroup taskGroup)
        {
            var taskGroupModel = _context.TaskGroups.Attach(taskGroup);
            taskGroupModel.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return taskGroup;
        }

        public UserTask Update(UserTask userTask)
        {
            var userTaskModel = _context.UserTasks.Attach(userTask);
            userTaskModel.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return userTask;
        }

        public UserCollection Update(UserCollection user)
        {
            var UserCollectionModel = _context.UserCollections.Attach(user);
            UserCollectionModel.State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            _context.SaveChanges();
            
            return user;

        }
    }
}
