using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MemoryGame
{
    public static class SoundManager
    {
        private static MediaPlayer _mediaPlayer = new MediaPlayer();
        private static MediaPlayer _effectPlayer = new MediaPlayer();

        public static void OpenMusic(string relativePath)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "MP3 files (*.mp3)|*.mp3|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                _mediaPlayer.Open(new Uri(openFileDialog.FileName));
                _mediaPlayer.Play();
            }
        }

        public static void PlayBackgroundMusic()
        {
            _mediaPlayer.Open(new Uri(Path.Combine(Environment.CurrentDirectory, "Assets/background_music.mp3")));
            _mediaPlayer.Play();
        }

        public static void PlayCardFlip()
        {
            PlayEffect("card_flip.mp3");
        }

        public static void PlayCorrect()
        {
            PlayEffect("correct_match.mp3");
        }

        public static void PlayIncorrect()
        {
            PlayEffect("incorrect_match.mp3");
        }

        private static void PlayEffect(string fileName)
        {
            _effectPlayer.Open(new Uri(Path.Combine(Environment.CurrentDirectory, "Assets/SoundEffects/" + fileName)));
            _effectPlayer.Play();
        }
    }
}
