using NUnit.Framework;
using MemoryGame;
using MemoryGame.Views;
using MemoryGame.ViewModels;
using MemoryGame.Models;

namespace MemoryGame.Test
{
    [TestFixture]
    public class ViewModelTests
    {
        static MainWindow mainWindow;

        [SetUp]
        public void Setup()
        {
            mainWindow = new MainWindow();
            Assert.IsInstanceOf<StartMenuViewModel>(mainWindow.DataContext);
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}