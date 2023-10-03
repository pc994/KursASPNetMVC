using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task = TaskApp.Domain.Entity.Task;

namespace TaskApp.App.Abstract
{
    public interface ITaskService
    {
        Task GetTaskById(int taskId);
        List<Task> GetAllTasks();
        int AddTask(Task task);
        int GetLastTaskId();
        void RemoveTask(int taskId);
        int UpdateTask(Task task);
        List<Task> GetTaskByParams(string paramsTypeName, string paramName);
    }
}
