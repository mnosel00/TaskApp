using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TaskApp.Models;

namespace TaskApp.Controllers
{
    public class HomeController : Controller
    {
        private ITaskInterface _taskInterface;

        public HomeController(ITaskInterface taskInterface)
        {

            _taskInterface = taskInterface;
        }

        public IActionResult Index( string sortBy)
        {

            ViewBag.SortByName = string.IsNullOrEmpty(sortBy) ? "Name desc" : "";
            ViewBag.SortByNumber = sortBy == "NumberOfTasks" ? "NumberOfTasks desc" : "NumberOfTasks";



            var modelSort = _taskInterface.GetAllTaskGroups().AsQueryable();

           
            var model= _taskInterface.GetAllTaskGroups();
            var model3 = _taskInterface.GetAllUserTask().GroupBy(x => x.TaskGroupId);
            foreach (var item in model)
            {
               
                var test = model3.Where(x => x.Key == item.Id);
                if (test.ToList().Count()==0)
                {
                    item.Licznik = 0;
                    continue;
                }
            
               
                item.Licznik = model3.Where(x => x.Key == item.Id).FirstOrDefault().Count();
                
            }
         

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            _taskInterface.Delete(id);
            return RedirectToAction("Index");
        }
      
      
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(TaskGroup taskGroup)
        {
            //UserTask NewuserTask = _taskInterface.Add(userTask);
            TaskGroup NewtaskGroup = _taskInterface.Add(taskGroup);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            var model = _taskInterface.GetAllTaskGroups();
            var model2 = _taskInterface.GetAllUserTask();
            ViewBag.Users = _taskInterface.GetAllUsers();
            ViewBag.GroupTask = model;
            ViewBag.UserTask = model2;
            ViewBag.Users = _taskInterface.GetAllUsers();




            var model3 = model2.GroupBy(x => x.TaskGroupId);
            var UserTaskList = new List<ViewModelUserTaskList>(); 
            foreach (var item in model)
            {
               
                var test = model3.Where(x => x.Key == item.Id);
                
                if (test.ToList().Count()==0)
                {
                    item.Licznik = 0;
                    continue;

                }

                var ViewModelUserTaskList = new ViewModelUserTaskList();
                ViewModelUserTaskList.UserTasksList = new List<UserTask>();
                ViewModelUserTaskList.TaskGroupId = item.Id;

                foreach (var item2 in test.FirstOrDefault())
                {
                    ViewModelUserTaskList.UserTasksList.Add(item2);
                }



                UserTaskList.Add(ViewModelUserTaskList);

                
            }
            ViewBag.UserTaskList = UserTaskList.Find(x=>x.TaskGroupId == id);






            TaskGroup IDtaskGroup = _taskInterface.GetTaskGroup(id);
            TaskGroup taskGroup = new TaskGroup()
            {
                Id = IDtaskGroup.Id,
                NameOfTaskGroup=IDtaskGroup.NameOfTaskGroup
            };
            return View(taskGroup);
        }

        [HttpPost]
        public IActionResult Edit(TaskGroup model)
        {
            if (ModelState.IsValid)
            {
                TaskGroup taskGroup = _taskInterface.GetTaskGroup(model.Id);
                taskGroup.NameOfTaskGroup = model.NameOfTaskGroup;
                TaskGroup UpdatedtaskGroup = _taskInterface.Update(taskGroup);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public ViewResult CreateUserTask()
        {
            ViewBag.Users = _taskInterface.GetAllUsers();
            ViewBag.GroupTask = _taskInterface.GetAllTaskGroups();
            ViewBag.UserTask = _taskInterface.GetAllUserTask();
           
            
            return View();
            
        }
        [HttpPost]
        public IActionResult CreateUserTask(UserTask userTask)
        {
            if (ModelState.IsValid)
            {
                UserTask NewuserTask = _taskInterface.Add(userTask);
            }
   
            
            return RedirectToAction("Edit", new { id = userTask.TaskGroupId });
        }

    }
}
