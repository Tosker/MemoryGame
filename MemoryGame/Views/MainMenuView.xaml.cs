using MemoryGame.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MemoryGame.Views
{
    /// <summary>
    /// Interaction logic for MainMenuView.xaml
    /// </summary>
    public partial class MainMenuView : UserControl
    {
        public MainMenuView()
        {
            InitializeComponent();
        }

        private void Slide_Clicked(object sender, RoutedEventArgs e)
        {
            var game = DataContext as GameViewModel;
            var button = sender as Button;
            game.ClickedSlide(button.DataContext as PictureViewModel);
        }

        private void PlayAgain_C(object sender, RoutedEventArgs e)
        {
            var game = DataContext as GameViewModel;
            game.Restart();
        }
    }
}
