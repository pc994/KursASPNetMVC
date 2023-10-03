using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2_homework_TaskSystem
{
    public class MenuActionService
    {
        private List<MenuAction> actions = new List<MenuAction>();

        public void AddNewAction(int id, string name, string menuName)
        {
            MenuAction menuAction = new MenuAction() { Id = id, Name = name, MenuName = menuName};
           actions.Add(menuAction);
        }
        
        public List<MenuAction> GetMenuActionByMenuName(string menuName)
        {
            List<MenuAction> result = new List<MenuAction>();
            foreach (var menuAction in actions)
            {
                if(menuAction.MenuName == menuName)
                {
                    result.Add(menuAction);
                }
            }
            return result;
        }
    }
}
