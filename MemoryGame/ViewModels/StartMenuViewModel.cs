using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame.ViewModels
{
    public class StartMenuViewModel
    {
        private MainWindow _mainWindow;
        public StartMenuViewModel(MainWindow main)
        {
            _mainWindow = main;
            SoundManager.PlayBackgroundMusic();
        }

        public int SelectedCategory{ get; set; }

        public void StartNewGame()
        {
            if(SelectedCategory > 0)
            {
                var category = (SlideCategories)SelectedCategory;
                _mainWindow.DataContext = new GameViewModel(category);
            }
        }
    }
}
