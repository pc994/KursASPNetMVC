using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using TaskApp.App.Concrete;
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
            int categoryId;
            string categoryName;
            string taskName;
            string taskDescription;
            int priorityId;
            string priorityName;
            bool correctChoice = true;
            Console.WriteLine();

            Console.WriteLine("Please Select category of your problem: ");
            var taskCategory = _paramsService.GetParametersByTypeName("Category");
            for(int i = 0; i< taskCategory.Count; i++)
            {
                Console.WriteLine($"{taskCategory[i].Id}. {taskCategory[i].Name}");
            }
            var choice = Console.ReadKey();
            Console.WriteLine();
            Int32.TryParse(choice.KeyChar.ToString(), out categoryId);
            while (categoryId <1 || categoryId > taskCategory.Count )
            {
                Console.WriteLine("Please select correct value!");
                choice = Console.ReadKey();
                Console.WriteLine();
                Int32.TryParse(choice.KeyChar.ToString(), out categoryId);
            }
            var test = taskCategory.Select(t => t.Id).ToList();
            categoryName = _paramsService.Parameters.Where(p => p.Id == categoryId).Select(p=>p.Name).FirstOrDefault();

            Console.Write("Please enter name for task: ");
            taskName = Console.ReadLine();
            while(string.IsNullOrEmpty(taskName) || string.IsNullOrWhiteSpace(taskName))
            {
                Console.Write("Name can not be empty! Please enter name for task: ");
                taskName = Console.ReadLine();
                Console.WriteLine();
            }

            Console.Write("Please enter description your problem: ");
            taskDescription = Console.ReadLine();
            Console.WriteLine();
            while (string.IsNullOrEmpty(taskDescription) || string.IsNullOrWhiteSpace(taskDescription))
            {
                Console.Write("Description can not be empty! Please enter description for task: ");
                taskDescription = Console.ReadLine();
                Console.WriteLine();
            }
            Console.WriteLine("Please enter priority number of your problem: ");
            var taskPriority = _paramsService.GetParametersByTypeName("Priority");
            for (int i = 0; i < taskPriority.Count; i++)
            {
                Console.WriteLine($"{taskPriority[i].Id}. {taskPriority[i].Name}");
            }
            choice = Console.ReadKey();
            Console.WriteLine();
            Int32.TryParse(choice.KeyChar.ToString(), out priorityId);
            while (priorityId < 1 || priorityId > taskPriority.Count)
            {
                Console.WriteLine("Please select correct value!");
                choice = Console.ReadKey();
                Console.WriteLine();
                Int32.TryParse(choice.KeyChar.ToString(), out priorityId);
            }
            priorityName = _paramsService.Parameters.Where(p=>p.Id == priorityId && p.TypeName == "Priority").Select(p => p.Name).FirstOrDefault();

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
                Console.Write("Please enter Id task to remove: ");
                int taskId;
                Int32.TryParse(Console.ReadLine(), out taskId);
                var task = _taskService.GetTaskById(taskId);
                while (task is null)
                {
                    Console.Write("Task not found, please enter existing id: ");
                    Int32.TryParse(Console.ReadLine(), out taskId);
                    task = _taskService.GetTaskById(taskId);
                }
                Console.WriteLine();
                _taskService.RemoveTask(taskId);
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
                Console.WriteLine();
                Console.Write("Please enter Id task to modify: ");
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
                        while (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
                        {
                            Console.Write("Description can not be empty! Please enter description for task: ");
                            name = Console.ReadLine();
                        }
                        task.Name = name;
                        break;
                    case '2':
                        Console.Write("Please enter new description for task: ");
                        string description = Console.ReadLine();
                        Console.WriteLine();
                        while (string.IsNullOrEmpty(description) || string.IsNullOrWhiteSpace(description))
                        {
                            Console.Write("Description can not be empty! Please enter description for task: ");
                            description = Console.ReadLine();
                            Console.WriteLine();
                        }
                        task.Description = description;
                        break;
                    case '3':
                        Console.WriteLine("Please select new category of your problem: ");
                        var taskCategory = _paramsService.GetParametersByTypeName("Category");
                        for (int i = 0; i < taskCategory.Count; i++)
                        {
                            Console.WriteLine($"{taskCategory[i].Id}. {taskCategory[i].Name}");
                        }
                        int categoryId;
                        Int32.TryParse(Console.ReadKey().KeyChar.ToString(), out categoryId);
                        while (categoryId < 1 || categoryId > taskCategory.Count)
                        {
                            Console.WriteLine("Please select correct value!");
                            choice = Console.ReadKey();
                            Console.WriteLine();
                            Int32.TryParse(choice.KeyChar.ToString(), out categoryId);
                        }
                        task.CategoryId = categoryId;
                        task.CategoryName = _paramsService.Parameters.Where(t => t.Id == categoryId && t.TypeName == "Category").Select(t => t.Name).FirstOrDefault();
                        break;
                    case '4':
                        Console.WriteLine("Please select new status of your problem: ");
                        var taskStatus = _paramsService.GetParametersByTypeName("Status");
                        for (int i = 0; i < taskStatus.Count; i++)
                        {
                            Console.WriteLine($"{taskStatus[i].Id}. {taskStatus[i].Name}");
                        }
                        int statusId;
                        Int32.TryParse(Console.ReadKey().KeyChar.ToString(), out statusId);
                        while (statusId < 1 || statusId > taskStatus.Count)
                        {
                            Console.WriteLine("Please select correct value!");
                            choice = Console.ReadKey();
                            Console.WriteLine();
                            Int32.TryParse(choice.KeyChar.ToString(), out statusId);
                        }
                        task.StatusId = statusId;
                        task.StatusName = _paramsService.Parameters.Where(t => t.Id == statusId && t.TypeName == "Status").Select(t => t.Name).FirstOrDefault();
                        break;
                    case '5':
                        Console.WriteLine("Please select new priority of your problem: ");
                        var taskPriority = _paramsService.GetParametersByTypeName("Priority");
                        for (int i = 0; i < taskPriority.Count; i++)
                        {
                            Console.WriteLine($"{taskPriority[i].Id}. {taskPriority[i].Name}");
                        }
                        int priorityId;
                        Int32.TryParse(Console.ReadKey().KeyChar.ToString(), out priorityId);
                        while (priorityId < 1 || priorityId > taskPriority.Count)
                        {
                            Console.WriteLine("Please select correct value!");
                            choice = Console.ReadKey();
                            Console.WriteLine();
                            Int32.TryParse(choice.KeyChar.ToString(), out priorityId);
                        }
                        task.PriorityId = priorityId;
                        task.PriorityName = _paramsService.Parameters.Where(t => t.Id == priorityId && t.TypeName == "Priority").Select(t => t.Name).FirstOrDefault();
                        break;
                    default:
                        Console.WriteLine("Please select existing option");
                        break;
                }
                _taskService.UpdateTask(task);
            }
            Console.WriteLine("Task updated successfully!\n");
        }

        public ConsoleKeyInfo ShowTaskAction()
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

        public void GetTasksByParams(ConsoleKeyInfo choice)
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
                for (int i = 0; i < taskCategory.Count; i++)
                {
                    Console.WriteLine($"{taskCategory[i].Id}. {taskCategory[i].Name}");
                }
                int categoryId;
                Int32.TryParse(Console.ReadKey().KeyChar.ToString(), out categoryId);
                Console.WriteLine();
                while (categoryId < 1 || categoryId > taskCategory.Count)
                {
                    Console.WriteLine("Please select correct value!");
                    choice = Console.ReadKey();
                    Int32.TryParse(choice.KeyChar.ToString(), out categoryId);
                }
                var categoryToShow = taskCategory.Where(t=>t.Id == categoryId).Select(t=>t.Name).FirstOrDefault();
                tasks = _taskService.GetTaskByParams("Category", categoryToShow);
                if (!tasks.Any())
                {
                    Console.WriteLine($"List tasks with \"{categoryToShow}\" is empty!");
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
            else if (choice.KeyChar == '3')
            {
                Console.WriteLine("Please select status name: ");
                var taskStatus = _paramsService.GetParametersByTypeName("Status");
                for (int i = 0; i < taskStatus.Count; i++)
                {
                    Console.WriteLine($"{taskStatus[i].Id}. {taskStatus[i].Name}");
                }
                int statusId;
                Int32.TryParse(Console.ReadKey().KeyChar.ToString(), out statusId);
                Console.WriteLine();
                while (statusId < 1 || statusId > taskStatus.Count)
                {
                    Console.WriteLine("Please select correct value!");
                    choice = Console.ReadKey();
                    Console.WriteLine();
                    Int32.TryParse(choice.KeyChar.ToString(), out statusId);
                }
                var statusToShow = taskStatus.Where(t => t.Id == statusId).Select(t => t.Name).FirstOrDefault();
                 tasks = _taskService.GetTaskByParams("Status", statusToShow);
                if (!tasks.Any())
                {
                    Console.WriteLine();
                    Console.WriteLine($"List tasks with \"{statusToShow}\" status is empty!");
                    Console.WriteLine();
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
            else if (choice.KeyChar == '4')
            {
                Console.WriteLine("Please select priority name: ");
                var taskPriority = _paramsService.GetParametersByTypeName("Priority");
                for (int i = 0; i < taskPriority.Count; i++)
                {
                    Console.WriteLine($"{taskPriority[i].Id}. {taskPriority[i].Name}");
                }
                int priorityId;
                Int32.TryParse(Console.ReadKey().KeyChar.ToString(), out priorityId);
                Console.WriteLine();
                while (priorityId < 1 || priorityId > taskPriority.Count)
                {
                    Console.WriteLine("Please select correct value!");
                    choice = Console.ReadKey();
                    Console.WriteLine();
                    Int32.TryParse(choice.KeyChar.ToString(), out priorityId);
                }
                var priorityToShow = taskPriority.Where(t => t.Id == priorityId).Select(t => t.Name).FirstOrDefault();
                tasks = _taskService.GetTaskByParams("Priority", priorityToShow);
                if (!tasks.Any())
                {
                    Console.WriteLine();
                    Console.WriteLine($"List tasks with \"{priorityToShow}\" priority is empty!");
                    Console.WriteLine();
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
            else if (choice.KeyChar == '5')
            {
                Console.Write("Please enter Id task: ");
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
    }
}
