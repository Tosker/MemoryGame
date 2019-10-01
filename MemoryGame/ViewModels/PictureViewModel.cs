using MemoryGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace MemoryGame.ViewModels
{
    public class PictureViewModel : ObservableObject
    {
        //Model for this view
        private PictureModel _model;

        //ID of this slide
        public int Id { get; private set; }

        //Slide status
        private bool _isViewed;
        private bool _hasBeenMatched;
        private bool _failedToMatch;

        //Is being viewed by user
        public bool IsViewed
        {
            get
            {
                return _isViewed;
            }
            private set
            {
                _isViewed = value;
                OnPropertyChanged("SlideImage");
                OnPropertyChanged("BorderBrush");
            }
        }

        //Has been matched
        public bool HasBeenMatched
        {
            get
            {
                return _hasBeenMatched;
            }
            private set
            {
                _hasBeenMatched = value;
                OnPropertyChanged("SlideImage");
                OnPropertyChanged("BorderBrush");
            }
        }

        //Has failed to be matched
        public bool FailedToMatch
        {
            get
            {
                return _failedToMatch;
            }
            private set
            {
                _failedToMatch = value;
                OnPropertyChanged("SlideImage");
                OnPropertyChanged("BorderBrush");
            }
        }

        //User can select this slide
        public bool IsSelectable
        {
            get
            {
                if (HasBeenMatched || IsViewed)
                    return false;

                return true;
            }
        }

        //Image to be displayed
        public string SlideImage
        {
            get
            {
                if (HasBeenMatched || IsViewed)
                    return _model.ImageSource;
                
                return "/MemoryGame;component/Assets/Other/mystery_image.jpg";
            }
        }

        //Brush color of border based on status
        public Brush BorderBrush
        {
            get
            {
                if (FailedToMatch)
                    return Brushes.Red;
                if (HasBeenMatched)
                    return Brushes.Green;
                if (IsViewed)
                    return Brushes.Yellow;

                return Brushes.Black;
            }
        }


        public PictureViewModel(PictureModel model)
        {
            _model = model;
            Id = model.Id;
        }

        //Has been matched
        public void MarkMatched()
        {
            HasBeenMatched = true;
        }

        //Has failed to match
        public void MarkFailed()
        {
            FailedToMatch = true;
        }

        //No longer being viewed
        public void StopPeeking()
        {
            IsViewed = false;
            FailedToMatch = false;
            OnPropertyChanged("isSelectable");
            OnPropertyChanged("SlideImage");
        }

        //Let user view
        public void PeekAtImage()
        {
            IsViewed = true;
            OnPropertyChanged("SlideImage");
        }
    }
}
