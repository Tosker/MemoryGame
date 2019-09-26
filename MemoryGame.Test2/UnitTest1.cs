using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MemoryGame;
using MemoryGame.Views;
using MemoryGame.ViewModels;
using MemoryGame.Models;

namespace MemoryGame.Test
{
    [TestClass]
    public class ViewModelTests
    {
        static MainWindow mainWindow;
        object currDataContext;

        [TestInitialize]
        public void Setup()
        {
            mainWindow = new MainWindow();
            currDataContext = mainWindow.DataContext as StartMenuViewModel;
        }

        [TestMethod]
        public void CheckStartingVM()
        {
            Assert.IsNotNull(currDataContext);
            Assert.IsInstanceOfType(currDataContext, typeof(StartMenuViewModel));
        }

        [TestMethod]
        public void SelectNothing()
        {
            StartMenuViewModel startDataContext = currDataContext as StartMenuViewModel;
            startDataContext.SelectedCategory = 0;
            startDataContext.StartNewGame();
            currDataContext = currDataContext = mainWindow.DataContext as StartMenuViewModel;

            CheckStartingVM();
        }
    }
}