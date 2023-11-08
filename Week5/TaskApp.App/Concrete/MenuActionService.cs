using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.App.Abstract;
using TaskApp.Domain.Entity;

namespace TaskApp.App.Concrete
{
    public class MenuActionService : IMenuActionsService
    {
        public List<MenuAction> Actions { get; set; }
        public MenuActionService()
        {
            Actions = new List<MenuAction>();
        }

        public void AddMenuAction(MenuAction menuAction)
        {
            Actions.Add(menuAction);
        }

        public List<MenuAction> GetMenuActionsByMenuName(string menuName)
        {
            List<MenuAction> result = new List<MenuAction>();
            foreach (var action in Actions)
            {
                if (action.MenuName == menuName)
                {
                    result.Add(action);
                }
            }
            return result;
        }  
    }
}
