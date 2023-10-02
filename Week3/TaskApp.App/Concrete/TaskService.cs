using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskApp.App.Abstract;
using Task = TaskApp.Domain.Entity.Task;

namespace TaskApp.App.Concrete
{
    public class TaskService : ITaskService
    {
        List<Task> Tasks { get; set; }
        public TaskService()
        {
            Tasks = new List<Task>();
        }

        public int AddTask(Task task)
        {
            Tasks.Add(task);
            return task.Id;
        }

        public List<Task> GetAllTasks()
        {
            return Tasks;
        }

        public bool CheckTasksList()
        {
            Console.WriteLine();
            bool isEmpty = true;
            if (!Tasks.Any())
            {
                Console.WriteLine();
                Console.WriteLine("List of tasks is empty!");
                Console.WriteLine();
            }
            else
            {
                isEmpty = false;
            }    
            return isEmpty;
        }

        public int GetLastTaskId()
        {
            int lastId;
            if (Tasks.Any())
            {
                lastId = Tasks.OrderBy(t => t.Id).LastOrDefault().Id;
            }
            else
            {
                lastId = 0;
            }
            return lastId;
        }

        public Task GetTaskById(int taskId)
        {
            var task = Tasks.FirstOrDefault(t => t.Id == taskId);
            return task;
        }

        public void RemoveTask(int taskId)
        {
            var taskToReemove = Tasks.FirstOrDefault(t => t.Id == taskId);
            Tasks.Remove(taskToReemove);
        }

        public int UpdateTask(Task task)
        {
            var entity = Tasks.FirstOrDefault(t => t.Id == task.Id);
            if (entity != null)
            {
                entity = task;
            }
            return entity.Id;
        }

        public List<Task> GetTaskByParams(string paramsTypeName, string paramName)
        {
            var tasks = GetAllTasks();
            if(paramsTypeName == "Category")
            {
                tasks = Tasks.Where(t => t.CategoryName == paramName).ToList();
            }else if(paramsTypeName == "Status")
            {
                tasks = Tasks.Where(t => t.StatusName == paramName).ToList();
            }else if( paramsTypeName == "Priority")
            {
                tasks = Tasks.Where(t => t.PriorityName == paramName).ToList();
            }
            return tasks;
        }
    }
}
