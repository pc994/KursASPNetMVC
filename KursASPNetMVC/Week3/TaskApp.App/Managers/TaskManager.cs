using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using TaskApp.App.Concrete;
using TaskApp.Domain.Entity;
using Task = TaskApp.Domain.Entity.Task;

namespace TaskApp.App.Managers
{
    public class TaskManager
    { 
        private readonly TaskService _taskService;
        private readonly MenuActionService _menuActionService;
        private readonly TaskParamsService _paramsService;

        public TaskManager(TaskService taskService, MenuActionService menuActionService, TaskParamsService paramsService)
        {
            _taskService = taskService;
            _menuActionService = menuActionService;
            _paramsService = paramsService;
        }

        public void AddTask()
        {
            Console.WriteLine("\nPlease Select category of your problem: ");
            var taskCategory = _paramsService.GetParametersByTypeName("Category");

            int categoryId = SetTaskParam(taskCategory);
            Console.WriteLine();
            string categoryName = _paramsService.Parameters.Where(p => p.Id == categoryId).Select(p=>p.Name).FirstOrDefault();

            Console.Write("Please enter name for task: ");
            string taskName = Console.ReadLine();
            taskName = SetTaskDetails(taskName);

            Console.Write("Please enter description your problem: ");
            string taskDescription = Console.ReadLine();
            Console.WriteLine();
            taskDescription = SetTaskDetails(taskDescription);

            Console.WriteLine("Please enter priority number of your problem: ");
            var taskPriority = _paramsService.GetParametersByTypeName("Priority");
            int priorityId = SetTaskParam(taskPriority);
            string priorityName = _paramsService.Parameters.Where(p=>p.Id == priorityId && p.TypeName == "Priority").Select(p => p.Name).FirstOrDefault();

            _taskService.AddTask(new Task(_taskService.GetLastTaskId()+1,taskName,taskDescription,categoryId,categoryName,1,"New",priorityId,priorityName));
            Console.WriteLine("Task added successfully!\n");
        }

        public void RemoveTask()
        {
            bool taskList = _taskService.CheckTasksList();
            if (taskList)
            {
                return;
            }
            else
            {
                var task =GetTaskByIdFromUser();
                _taskService.RemoveTask(task.Id);
                Console.WriteLine("Task deleted successfully! \n");
            }
        }

        public void UpdateTask()
        {
            bool taskList = _taskService.CheckTasksList();
            if (taskList)
            {
                return;
            }else
            {
                var task =GetTaskByIdFromUser();
                Console.WriteLine("What you want to do? ");
                var updateActions = _menuActionService.GetMenuActionsByMenuName("UpdateTask");
                foreach (var action in updateActions)
                {
                    Console.WriteLine($"{action.Id}. {action.Name}");
                }
                var choice = Console.ReadKey();
                Console.WriteLine();
                switch (choice.KeyChar)
                {
                    case '1':
                        Console.Write("Please enter new name for task: ");
                        string name = Console.ReadLine();
                        var setNewName = SetTaskDetails(name);
                        task.Name = setNewName;
                        break;
                    case '2':
                        Console.Write("Please enter new description for task: ");
                        string description = Console.ReadLine();
                        var setNewDescription = SetTaskDetails(description);
                        task.Description = setNewDescription;
                        break;
                    case '3':
                        Console.WriteLine("Please select new category of your problem: ");
                        var taskCategoryList = _paramsService.GetParametersByTypeName("Category");
                        var categoryId = SetTaskParam(taskCategoryList);
                        task.CategoryId = categoryId;
                        task.CategoryName = _paramsService.Parameters.Where(t => t.Id == categoryId && t.TypeName == "Category").Select(t => t.Name).FirstOrDefault();
                        break;
                    case '4':
                        Console.WriteLine("Please select new status of your problem: ");
                        var taskStatus = _paramsService.GetParametersByTypeName("Status");
                        int statusId = SetTaskParam(taskStatus);
                        task.StatusId = statusId;
                        task.StatusName = _paramsService.Parameters.Where(t => t.Id == statusId && t.TypeName == "Status").Select(t => t.Name).FirstOrDefault();
                        break;
                    case '5':
                        Console.WriteLine("Please select new priority of your problem: ");
                        var taskPriority = _paramsService.GetParametersByTypeName("Priority");
                        int priorityId = SetTaskParam(taskPriority);
                        task.PriorityId = priorityId;
                        task.PriorityName = _paramsService.Parameters.Where(t => t.Id == priorityId && t.TypeName == "Priority").Select(t => t.Name).FirstOrDefault();
                        break;
                    default:
                        Console.WriteLine("Please select existing option");
                        break;
                }
                _taskService.UpdateTask(task);
            }
            Console.WriteLine("\nTask updated successfully!\n");
        }

        private void GetTasksByParams(ConsoleKeyInfo choice)
        {
            var tasks = _taskService.GetAllTasks();

            if (choice.KeyChar == '1')
            {
                Console.WriteLine();
                foreach (var task in tasks)
                {
                    Console.WriteLine($"ID: {task.Id}\t NAME: {task.Name}\t CATEGORY: {task.CategoryName}\t STATUS: {task.StatusName}\t PRIORITY: {task.PriorityName} ");
                }
                Console.WriteLine();
            }
            else if(choice.KeyChar == '2')
            {
                Console.WriteLine("Please select category name: ");
                var taskCategory = _paramsService.GetParametersByTypeName("Category");
                var categoryId = SetTaskParam(taskCategory);
                var categoryToShow = taskCategory.Where(t=>t.Id == categoryId).Select(t=>t.Name).FirstOrDefault();
                var task = _taskService.GetTaskByParams("Category", categoryToShow);
                ViewTaskByParam(task, categoryToShow);
            }
            else if (choice.KeyChar == '3')
            {
                Console.WriteLine("Please select status name: ");
                var taskStatus = _paramsService.GetParametersByTypeName("Status");
                var statusId = SetTaskParam(taskStatus);
                var statusToShow = taskStatus.Where(t => t.Id == statusId).Select(t => t.Name).FirstOrDefault();
                var task = _taskService.GetTaskByParams("Status", statusToShow);
                ViewTaskByParam(task, statusToShow);
            }
            else if (choice.KeyChar == '4')
            {
                Console.WriteLine("Please select priority name: ");
                var taskPriority = _paramsService.GetParametersByTypeName("Priority");
                var priorityId = SetTaskParam(taskPriority);
                var priorityToShow = taskPriority.Where(t => t.Id == priorityId).Select(t => t.Name).FirstOrDefault();
                var task = _taskService.GetTaskByParams("Priority", priorityToShow);
                ViewTaskByParam(task, priorityToShow);
            }
            else if (choice.KeyChar == '5')
            {
                var task = GetTaskByIdFromUser();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"\nID:\t\t\t");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(task.Id);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\nNAME: \t\t\t");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(task.Name);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("DESCRIPTION: \t\t");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(task.Description);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\nCATEGORY: \t\t");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(task.CategoryName);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("STATUS: \t\t");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(task.StatusName);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("PRIORITY: \t\t");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(task.PriorityName);
            }
        }

        public void ViewTasks()
        {
            bool taskList = _taskService.CheckTasksList();
            if (taskList)
            {
                return;
            }
            else
            {
                var choice = ShowTaskAction();
                GetTasksByParams(choice);
            }
        }

        private string SetTaskDetails(string value)
        {
            while (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                Console.Write("Value can not be empty! Please enter value: ");
                value = Console.ReadLine();
            }
            return value;
        }

        private int SetTaskParam(List<TaskParameters> paramList)
        {
            for (int i = 0; i < paramList.Count; i++)
            {
                Console.WriteLine($"{paramList[i].Id}. {paramList[i].Name}");
            }
            int paramId;
            Int32.TryParse(Console.ReadKey().KeyChar.ToString(), out paramId);
            while (paramId < 1 || paramId > paramList.Count)
            {
                Console.WriteLine("Please select correct value!");
                var choice = Console.ReadKey();
                Console.WriteLine();
                Int32.TryParse(choice.KeyChar.ToString(), out paramId);
            }
            return paramId;
        }

        private ConsoleKeyInfo ShowTaskAction()
        {
            Console.WriteLine();
            var actions = _menuActionService.GetMenuActionsByMenuName("ShowTask");
            foreach (var action in actions)
            {
                Console.WriteLine($"{action.Id}. {action.Name}");
            }
            var choice = Console.ReadKey();
            Console.WriteLine();
            return choice;
        }

        private Task GetTaskByIdFromUser()
        {
            Console.WriteLine();
            Console.Write("Please enter task id number: ");
            int taskId;
            Int32.TryParse(Console.ReadLine(), out taskId);
            Console.WriteLine();

            var task = _taskService.GetTaskById(taskId);
            while (task is null)
            {
                Console.Write("Task not found, please enter existing id: ");
                Int32.TryParse(Console.ReadLine(), out taskId);
                task = _taskService.GetTaskById(taskId);
            }
            return task;
        }

        private void ViewTaskByParam(List<Task> tasks, string paramTypeName)
        {
            if (!tasks.Any())
            {
                Console.WriteLine($"List tasks with \"{paramTypeName}\" is empty!");
            }
            else
            {
                Console.WriteLine();
                foreach (var task in tasks)
                {
                    Console.WriteLine($"ID: {task.Id}\t NAME: {task.Name}\t CATEGORY: {task.CategoryName}\t STATUS: {task.StatusName}\t PRIORITY: {task.PriorityName} ");
                }
                Console.WriteLine();
            }
        }
    }
}
