using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.App.Abstract;
using TaskApp.App.Concrete;
using TaskApp.App.Managers;
using TaskApp.Domain.Entity;

namespace TaskApp.Tests
{
    public class MenuActionServiceTests
    {
        [Theory]
        [InlineData("Main")]
        [InlineData("ShowTask")]
        [InlineData("Category")]
        [InlineData("Status")]
        [InlineData("Priority")]
        [InlineData("UpdateTask")]
        public void GetMenuActionsByMenuName_ForDifferentMenuName_ReturnsMenuActions(string menuName)
        {
            //Arrange
            MenuActionService menuActionService = new MenuActionService();
            MenuActionManager menuActionManager = new MenuActionManager(menuActionService);
            //Act
            var menu = menuActionService.GetMenuActionsByMenuName(menuName);
            var result = menu.Where(m => m.MenuName == menuName).Select(s => s.MenuName).FirstOrDefault();
            //Assert
            Assert.Equal(menuName, result);
        }

        [Fact]
        public void AddMenuAction_AddMenuActionsToList_ReturnListOfMenuAction()
        {
            //Arrange
            MenuActionService menuActionService = new MenuActionService();
            MenuAction menuAction = new MenuAction(1, "Software problem", "Category");
            //Act
            menuActionService.AddMenuAction(menuAction);
            //Assert
            Assert.Contains(menuAction, menuActionService.Actions);
        }
    }
}
