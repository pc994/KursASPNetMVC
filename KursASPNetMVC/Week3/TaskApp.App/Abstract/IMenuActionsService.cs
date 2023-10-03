using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Domain.Entity;

namespace TaskApp.App.Abstract
{
    public interface IMenuActionsService
    {
        List<MenuAction> Actions { get; set; }
        void AddMenuAction(MenuAction menuAction);
        List<MenuAction> GetMenuActionsByMenuName(string menuName);
    }
}
