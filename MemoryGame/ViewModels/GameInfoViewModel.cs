using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MemoryGame.ViewModels
{
    public class GameInfoViewModel : ObservableObject
    {
        private const int _maxAttempts = 4;
        private const int _pointAward = 75;
        private const int _pointDeduction = 15;

        private int _matchAttempts;
        private int _score;

        private bool? _isGameWon;

        public int MatchAttempts
        {
            get
            {
                return _matchAttempts;
            }
            private set
            {
                _matchAttempts = value;
                OnPropertyChanged("MatchAttempts");
            }
        }

        public int Score
        {
            get
            {
                return _score;
            }
            private set
            {
                _score = value;
                OnPropertyChanged("Score");
            }
        }

        public Visibility LostMessage
        {
            get
            {
                if (_isGameWon == false)
                    return Visibility.Visible;

                return Visibility.Hidden;
            }
        }

        public Visibility WinMessage
        {
            get
            {
                if (_isGameWon == true)
                    return Visibility.Visible;

                return Visibility.Hidden;
            }
        }

        public void SetGameStatus(bool? isWin)
        {
            if (isWin == true)
            {
                _isGameWon = true;
                OnPropertyChanged("WinMessage");
            }
            else if (isWin == false)
            {
                _isGameWon = false;
                OnPropertyChanged("LostMessage");
            }
        }

        public void ClearInfo()
        {
            Score = 0;
            MatchAttempts = _maxAttempts;
            _isGameWon = null;
            OnPropertyChanged("LostMessage");
            OnPropertyChanged("WinMessage");
        }

        public void Award()
        {
            Score += _pointAward;
            SoundManager.PlayCorrect();
        }

        public void Penalize()
        {
            Score -= _pointDeduction;
            MatchAttempts--;
            SoundManager.PlayIncorrect();
        }
    }
}
