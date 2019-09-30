using MemoryGame.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace MemoryGame.ViewModels
{
    public enum SlideCategories
    {
        Animals = 1,
        Cars = 2,
        Foods = 3
    }

    public class GameViewModel : ObservableObject
    {
        //Collection of slides we are playing with
        public SlideCollectionViewModel Slides { get; private set; }
        //Game information scores, attempts etc
        public GameInfoViewModel GameInfo { get; private set; }
        //Game timer for elapsed time
        public TimerViewModel Timer { get; private set; }
        //Category we are playing in
        public SlideCategories Category { get; private set; }

        public GameViewModel(SlideCategories category)
        {
            Category = category;
            SetupGame(category);
        }

        //Initialize game essentials
        private void SetupGame(SlideCategories category)
        {

            Slides = new SlideCollectionViewModel();
            Timer = new TimerViewModel(new TimeSpan(0, 0, 1));
            GameInfo = new GameInfoViewModel();
            string assetFolder = new ResourceManager().GetAssetsFolder(category.ToString());

            //Set attempts to the maximum allowed
            GameInfo.ResetInfo();

            //Create slides from image folder then display to be memorized
            Slides.CreateSlides(assetFolder);
            Slides.InitialPeek();

            //Game has started, begin count.
            Timer.Start();

            //Slides have been updated
            OnPropertyChanged("Slides");
            OnPropertyChanged("Timer");
            OnPropertyChanged("GameInfo");
        }

        //Slide has been clicked
        public void ClickedSlide(PictureViewModel slide)
        {
            if (Slides.canSelect)
            {
                Slides.SelectSlide(slide);
            }

            if (!Slides.areSlidesActive)
            {
                if (Slides.CheckIfMatched())
                    GameInfo.Award(); //Correct match
                else
                    GameInfo.Penalize(); //Incorrect match
            }

            CheckIfWin();
        }

        //Check status of the current game
        private void CheckIfWin()
        {
            if(GameInfo.MatchAttempts < 0)
            {
                GameInfo.SetGameStatus(false);
                Slides.RevealUnmatched();
                Timer.Stop();
            }
            if(Slides.AllSlidesMatched)
            {
                GameInfo.SetGameStatus(true);
                Timer.Stop();
            }
        }

        //Restart game
        public void Restart()
        {
            SoundManager.PlayIncorrect();
            SetupGame(Category);
        }
    }
}
