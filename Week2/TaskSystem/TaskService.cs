using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Week2_homework_TaskSystem
{
    public class TaskService
    {
        public List<Task> Tasks { get; set; }
        public TaskService()
        {
            Tasks = new List<Task>();
        }
        public ConsoleKeyInfo AddNewTaskView(MenuActionService actionService)
        {
            var addNewTaskMenu = actionService.GetMenuActionByMenuName("AddNewTaskMenu");
            Console.WriteLine("Please select task category: ");
            for (int i = 0; i < addNewTaskMenu.Count; i++)
            {
                Console.WriteLine($"{addNewTaskMenu[i].Id}. {addNewTaskMenu[i].Name}");
            }
            var operation = Console.ReadKey();
            return operation;
        }

        public int AddNewTask(char taskCategory)
        {
            Console.WriteLine();
            int taskId;
            Int32.TryParse(taskCategory.ToString(), out taskId);
            Task task = new Task();
            task.CategoryId = taskId;
            Console.Write("Please enter id for new task: ");
            var id = Console.ReadLine();
            task.Id = Int32.Parse(id);
            Console.Write("Please enter name for new task: ");
            task.Name= Console.ReadLine();
            Console.Write("Please describe your problem: ");
            task.Description = Console.ReadLine();
            task.Status = "New";
            Tasks.Add(task);
            return task.Id;
        }

        public int GetTaskByIdView()
        {
            Console.WriteLine();
            Console.Write("Please enter task id: ");
            int taskId = Int32.Parse(Console.ReadLine());
            var task = Tasks.Where(t => t.Id == taskId);
            return taskId;
        }
        public void RemoveTask(int taskId)
        {
            Console.WriteLine();
            Task taskToRemove = new Task();
            foreach(var task in Tasks)
            {
                if(task.Id == taskId)
                {
                    taskToRemove = task;
                    break;
                }
            }
            Tasks.Remove(taskToRemove);
        }

        public void GetTaskById(int id)
        {
            Console.WriteLine();
            string category;
            var task = Tasks.FirstOrDefault(t => t.Id == id);
            if (task.CategoryId == 1)
            {
                category = "Software problem";
            }else if (task.CategoryId == 2)
            {
                category = "Hardware problem";
            }else
            {
                category = "Other problem";
            }
            Console.WriteLine($"{task.Id}. {task.Name}. \n {task.Description} \n status: {task.Status} \n category: {category}");
        }
        public ConsoleKeyInfo ModifyTaskView(MenuActionService actionService)
        {
            Console.WriteLine();
            var modifyMenu = actionService.GetMenuActionByMenuName("EditTaskMenu");
            Console.WriteLine("What you want to do?");
            for (int i = 0; i < modifyMenu.Count; i++)
            {
                Console.WriteLine($"{modifyMenu[i].Id}. {modifyMenu[i].Name}");
            }
            var operation = Console.ReadKey();
            return operation;
        }
        public void ModifyTask(int taskId, ConsoleKeyInfo operation)
        {
            Console.WriteLine();
            var task = Tasks.FirstOrDefault(t => t.Id == taskId);
            switch (operation.KeyChar)
            {
                case '1':
                    Console.Write("Please enter new task name: ");
                    task.Name = Console.ReadLine();
                    break;
                case '2':
                    Console.Write("Please enter new task description: ");
                    task.Description = Console.ReadLine();
                    break;
                case '3':
                    Console.WriteLine("Please select new task status: ");
                    Console.WriteLine("1. In progress");
                    Console.WriteLine("2. Suspensed");
                    Console.WriteLine("3. Finished");
                    int status = Int32.Parse(Console.ReadLine());
                    if(status == 1)
                    {
                        task.Status = "In progress";
                    }else if(status == 2)
                    {
                        task.Status = "Suspensed";
                    }else if(status == 3)
                    {
                        task.Status = "Finished";
                    }
                    else
                    {
                        Console.WriteLine("You entered the wrong value");
                    }
                    break;
                case '4':
                    Console.WriteLine("Please select new task category: ");
                    Console.WriteLine("1. Software");
                    Console.WriteLine("2. Hardware");
                    Console.WriteLine("3. Other");
                    int category = Int32.Parse(Console.ReadLine());
                    if (category == 1)
                    {
                        task.CategoryId = 1;
                    }
                    else if (category == 2)
                    {
                        task.CategoryId = 2;
                    }
                    else if (category == 3)
                    {
                        task.CategoryId = 3;
                    }
                    else
                    {
                        Console.WriteLine("You entered the wrong value");
                    }
                    break;
                case '5':
                    RemoveTask(taskId);
                    break;
                default:
                    Console.WriteLine("You entered the wrong value");
                    break;
            }
        }

        public void ViewAllTasks()
        {
            Console.WriteLine();
            string category;
            foreach (var task in Tasks)
            {
                if (task.CategoryId == 1)
                {
                    category = "Software";
                } else if (task.CategoryId == 2)
                {
                    category = "Hardware";
                }else
                {
                    category = "Other";
                }
                Console.WriteLine($"Id: {task.Id} \n Name: \t\t {task.Name} \n Status: \t {task.Status} \n Category: \t {category}\n\n");
            }
        }
    }
}
