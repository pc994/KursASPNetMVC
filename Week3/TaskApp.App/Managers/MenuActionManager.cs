using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TaskApp.App.Concrete;
using TaskApp.Domain.Entity;

namespace TaskApp.App.Managers
{
    public class MenuActionManager
    {
        private readonly MenuActionService _menuActionService;

        public MenuActionManager(MenuActionService menuActionService)
        {
            _menuActionService = menuActionService;
            InitializeMenuActions();
        }

        public void InitializeMenuActions()
        {
            _menuActionService.AddMenuAction(new MenuAction(1, "Show tasks", "Main"));
            _menuActionService.AddMenuAction(new MenuAction(2, "Add task", "Main"));
            _menuActionService.AddMenuAction(new MenuAction(3, "Edit task", "Main"));
            _menuActionService.AddMenuAction(new MenuAction(4, "Remove task", "Main"));
            _menuActionService.AddMenuAction(new MenuAction(0, "Close app", "Main"));

            _menuActionService.AddMenuAction(new MenuAction(1, "View all tasks", "ShowTask"));
            _menuActionService.AddMenuAction(new MenuAction(2, "View tasks by category", "ShowTask"));
            _menuActionService.AddMenuAction(new MenuAction(3, "View tasks by status", "ShowTask"));
            _menuActionService.AddMenuAction(new MenuAction(4, "View tasks by priority", "ShowTask"));
            _menuActionService.AddMenuAction(new MenuAction(5, "View task details", "ShowTask"));
            _menuActionService.AddMenuAction(new MenuAction(0, "Back", "ShowTask"));

            _menuActionService.AddMenuAction(new MenuAction(1, "Software problem", "Category"));
            _menuActionService.AddMenuAction(new MenuAction(2, "Hardware problem", "Category"));
            _menuActionService.AddMenuAction(new MenuAction(3, "Other problem", "Category"));
            _menuActionService.AddMenuAction(new MenuAction(0, "Back", "Category"));

            _menuActionService.AddMenuAction(new MenuAction(1, "New", "Status"));
            _menuActionService.AddMenuAction(new MenuAction(2, "In progress", "Status"));
            _menuActionService.AddMenuAction(new MenuAction(3, "Suspensed", "Status"));
            _menuActionService.AddMenuAction(new MenuAction(4, "Finished", "Status"));
            _menuActionService.AddMenuAction(new MenuAction(0, "Back", "Status"));

            _menuActionService.AddMenuAction(new MenuAction(1, "Low", "Priority"));
            _menuActionService.AddMenuAction(new MenuAction(2, "Normal", "Priority"));
            _menuActionService.AddMenuAction(new MenuAction(3, "High", "Priority"));
            _menuActionService.AddMenuAction(new MenuAction(4, "Immediate", "Priority"));
            _menuActionService.AddMenuAction(new MenuAction(0, "Back", "Priority"));

            _menuActionService.AddMenuAction(new MenuAction(1, "Change name", "UpdateTask"));
            _menuActionService.AddMenuAction(new MenuAction(2, "Change description", "UpdateTask"));
            _menuActionService.AddMenuAction(new MenuAction(3, "Change category", "UpdateTask"));
            _menuActionService.AddMenuAction(new MenuAction(4, "Change Status", "UpdateTask"));
            _menuActionService.AddMenuAction(new MenuAction(5, "Chamge Priority", "UpdateTask"));
            _menuActionService.AddMenuAction(new MenuAction(0, "Back", "UpdateTask"));
        }

        public ConsoleKeyInfo InitMenu(string menuName)
        {
            var menu = _menuActionService.GetMenuActionsByMenuName(menuName);
            for (int i = 0; i < menu.Count; i++)
            {
                Console.WriteLine(menu[i].Id + ". " + menu[i].Name);
            }
            var choosenOperation = Console.ReadKey();
            return choosenOperation;
        }
    }
}
