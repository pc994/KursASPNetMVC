using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskApp.App.Abstract;
using TaskApp.App.Concrete;

namespace TaskApp.Tests
{
    public class TaskServiceTests
    {
        [Fact]
        public void AddTask_NewTaskForList_ReturnIdOfNewTask()
        {
            //Arrange
            var mock = new Mock<ITaskService>();
            Task task = new Task(2,"Name","Description",1,"Software problem",1,"New",1,"Low");
            mock.Setup(a => a.AddTask(task)).Returns(task.Id);
            //Act
            var result = mock.Object.AddTask(task);
            //Assert
            Assert.Equal(task.Id, result);
        }

        [Fact]
        public void GetTaskById_GetTaskFromListOfTasks_ReturnTask()
        {
            //Arrange
            var mock = new Mock<ITaskService>();
            Task task = new Task(1, "Name", "Description", 1, "Software problem", 1, "New", 1, "Low");
            mock.Setup(s => s.GetTaskById(1)).Returns(task);
            //Act
            var result = mock.Object.GetTaskById(1);
            //Assert
            Assert.Equal(task, result);
        }

        [Fact]
        public void GetAllTasks_GetTasksFromList_ReturnListOfTasks()
        {
            //Arrange
            var mock = new Mock<ITaskService>();
            mock.Setup(s => s.GetAllTasks()).Returns(new List<Task> 
            { 
                new Task(1, "Name", "Description", 1, "Software problem", 1, "New", 1, "Low"),
                new Task(2, "Name1", "Description1", 1, "Hardware problem", 1, "New", 1, "High"),
                new Task(3, "Name2", "Description2", 1, "Other problem", 1, "New", 1, "Low")
            });
            //Act
            var result = mock.Object.GetAllTasks();
            //Assert
            Assert.Equal(3, result.Count);
        }

        [Fact]
        public void GetLastTaskId_GetLastIdOfTaskFromList_ReturnId()
        {
            //Arrange
            var mock = new Mock<ITaskService>();
            Task task = new Task(2, "Name", "Description", 1, "Software problem", 1, "New", 1, "Low");
            mock.Setup(s => s.GetLastTaskId()).Returns(task.Id);
            //Act
            var result =  mock.Object.GetLastTaskId();
            //Assert
            Assert.Equal(task.Id, result);
        }

        [Fact]
        public void RemoveTask_RemoveTaskFromList_TaskNonExistsOnList()
        {
            //Arrange
            Task task = new Task(1, "Name", "Description", 1, "Software problem", 1, "New", 1, "Low");
            Task taskToRemove = new Task(2, "Name", "Description", 1, "Software problem", 1, "New", 1, "Low");
            TaskService taskService = new TaskService();
            taskService.Tasks.Add(task);
            taskService.Tasks.Add(taskToRemove);
            //Act
            taskService.RemoveTask(2);
            //Assert
            Assert.DoesNotContain(taskToRemove, taskService.Tasks);
        }

        [Fact]
        public void UpdateTask_UpdateTaskCategory_ReturnUpdatedTask()
        {
            //Arrange
            var mock = new Mock<ITaskService>();
            Task task = new Task(2, "Name", "Description", 1, "Software problem", 1, "New", 1, "Low");
            Task taskIpdate = new Task(2, "Name", "Description", 1, "Hardware problem", 1, "New", 1, "Low");
            mock.Setup(s => s.UpdateTask(taskIpdate)).Returns(taskIpdate.Id);
            //Act
            var result = mock.Object.UpdateTask(taskIpdate);
            //Assert
            Assert.Equal(taskIpdate.Id, result);
        }

        [Theory]
        [InlineData("Category", "Software problem")]
        [InlineData("Category", "Hardware problem")]
        [InlineData("Category","Other problem")]
        public void GetTaskByParams_ForCategoryParameter_ReturnsListWithCategoryParam(string paramTypeName, string paramName)
        {
            //Arrange
            var mock = new Mock<ITaskService>();
            var tasks = new List<Task>
            {
                new Task(1, "Name", "Description", 1, "Software problem", 2, "In progress", 1, "Low"),
                new Task(2, "Name", "Description", 1, "Software problem", 2, "In progress", 1, "Low"),
                new Task(2, "Name", "Description", 1, "Hardware problem", 3, "Finished", 1, "Low"),
                new Task(2, "Name", "Description", 1, "Hardware problem", 3, "Finished", 1, "Low"),
                new Task(3, "Name", "Description", 1, "Other problem", 4, "Suspensed", 1, "Low"),
                new Task(3, "Name", "Description", 1, "Other problem", 4, "Suspensed", 1, "Low")
            };
            mock.Setup(s => s.GetTaskByParams(paramTypeName, paramName)).Returns(tasks);
            //Act
            var result = mock.Object.GetTaskByParams(paramTypeName, paramName).Where(t => t.CategoryName == paramName).ToList();
            //Assert
            Assert.Equal(2, result.Count);
        }
    }
}
