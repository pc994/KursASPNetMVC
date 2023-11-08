// See https://aka.ms/new-console-template for more information


using TaskApp.App.Concrete;
using TaskApp.App.Managers;

Console.WriteLine("##############################");
Console.WriteLine("#-----Welcome in TaskApp-----#");
Console.WriteLine("##############################");
Console.WriteLine();

MenuActionService menuActionService = new MenuActionService();
MenuActionManager actionManager = new MenuActionManager(menuActionService);
TaskService taskService = new TaskService();
TaskParamsService taskParamsService = new TaskParamsService();
TaskManager taskManager = new TaskManager(taskService, menuActionService, taskParamsService);
while (true)
{
    Console.WriteLine("Please select menu option.");
    var mainMenu = actionManager.InitMenu("Main");
    switch (mainMenu.KeyChar)
    {
        case '1':
            taskManager.ViewTasks();
            break;
        case '2':
            taskManager.AddTask();
            break;
        case '3':
            taskManager.UpdateTask();
            break;
        case '4':
            taskManager.RemoveTask();
            break;
        case '0':
            return;
        default:
            Console.WriteLine();
            Console.WriteLine("You entered wrong options");
            Console.WriteLine();
            break;

    }

}