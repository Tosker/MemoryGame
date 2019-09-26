using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

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

        public bool CanPlay => Enum.GetValues(typeof(SlideCategories)).Cast<int>().Contains(SelectedCategory);

        RelayCommand _playCommand;
        public ICommand PlayCommand
        {
            get
            {
                if(_playCommand == null)
                {
                    _playCommand = new RelayCommand(param => StartNewGame(), param => CanPlay);
                }
                return _playCommand;
            }
        }


        public void StartNewGame()
        {
            var category = (SlideCategories)SelectedCategory;
            _mainWindow.DataContext = new GameViewModel(category);
        }
    }
}
