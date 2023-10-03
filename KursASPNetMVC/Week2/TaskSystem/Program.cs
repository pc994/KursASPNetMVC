// See https://aka.ms/new-console-template for more information

//PRACA DOMOWA Z DRUGIEGO TYGODNIA

//aplikacja TaskSystem ma odzwierciedlać działanie systemu zgłoszeniowego.
//użytkownik ma możliwość dodania, edycji, usuwania tasków, wyświetlenia
//szczegółów jednego taska lub wyświetlenia listy wszystkich tasków.

using Week2_homework_TaskSystem;

MenuActionService actionService = new MenuActionService();
actionService = Initialize(actionService);
TaskService taskService = new TaskService();

Console.WriteLine("Welcome to Task System.");
while(true)
{
    Console.WriteLine("Please let me know what you want to do: ");
    var mainMenu = actionService.GetMenuActionByMenuName("Main");
    for (int i = 0; i < mainMenu.Count; i++)
    {
        Console.WriteLine($"{mainMenu[i].Id}. {mainMenu[i].Name}");
    }

    var operation = Console.ReadKey();
    Console.WriteLine("\n");
    switch (operation.KeyChar)
    {
        case '1':
            var keyInfo = taskService.AddNewTaskView(actionService);
            var taskId = taskService.AddNewTask(keyInfo.KeyChar);
            break;
        case '2':
            var taskToModify = taskService.GetTaskByIdView();
            var modifyOperation = taskService.ModifyTaskView(actionService);
            taskService.ModifyTask(taskToModify, modifyOperation);
            break;
        case '3':
            var idToRemove = taskService.GetTaskByIdView();
            taskService.RemoveTask(idToRemove);
            break;
        case '4':
            var taskToShow = taskService.GetTaskByIdView();
            taskService.GetTaskById(taskToShow);
            break;
        case '5':
            taskService.ViewAllTasks();
            break;
        case '0':
            return;
        default:
            Console.WriteLine("Action you entered does not exist!");
            break;
    }
}

MenuActionService Initialize(MenuActionService actionService)
{
    actionService.AddNewAction(1, "Add task", "Main");
    actionService.AddNewAction(2, "Edit task", "Main");
    actionService.AddNewAction(3, "Delete task", "Main");
    actionService.AddNewAction(4, "Show task details", "Main");
    actionService.AddNewAction(5, "Show all tasks", "Main");
    actionService.AddNewAction(0, "Close app", "Main");

    actionService.AddNewAction(1, "Software problem", "AddNewTaskMenu");
    actionService.AddNewAction(2, "Hardware problem", "AddNewTaskMenu");
    actionService.AddNewAction(3, "Other problem", "AddNewTaskMenu");
    
    actionService.AddNewAction(1, "Change name", "EditTaskMenu");
    actionService.AddNewAction(2, "Change description", "EditTaskMenu");
    actionService.AddNewAction(3, "Change status", "EditTaskMenu");
    actionService.AddNewAction(4, "Change category", "EditTaskMenu");
    actionService.AddNewAction(5, "Delete task", "EditTaskMenu");
    return actionService;
}

