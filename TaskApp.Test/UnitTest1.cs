using Moq;
using TaskApp.App.Abstract;
using TaskApp.App.Concrete;
using TaskApp.App.Managers;
using Task = TaskApp.Domain.Entity.Task;
namespace TaskApp.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //Arrange - przygotowanie danych
            //int a = 4;
            //int b = 5;

            ////Act - wykonaj dzia³¹nie logiczne, które ma zostaæ przetestowane
            //int result = a+ b;

            ////Assert - dowód na to ¿e kod dzia³a w sposób prawid³owy
            //Assert.Equal(9, result);

            //Arrange
            Task task = new Task(1, "Nazwa", "Opis", 1, "Software problem", 1,"New",1,"Low");
            var mock = new Mock<TaskService>();
            mock.Setup(s => s.GetTaskById(1)).Returns(task);
            var manager = new TaskManager(mock.Object, new MenuActionService(), new TaskParamsService());
            //Act
            
            //Assert
        }
    }
} 