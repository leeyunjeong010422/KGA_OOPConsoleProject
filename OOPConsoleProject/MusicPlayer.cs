using WMPLib;

namespace OOPConsoleProject
{
    public class MusicPlayer
    {
        private WindowsMediaPlayer _player = new();

        public string Path
        {
            get => _player.URL;
            set => _player.URL = value;
        }

        public int Volume
        {
            get => _player.settings.volume;
            set => _player.settings.volume = value;
        }

        private bool _loop;
        public bool Loop
        {
            get => _loop;
            set
            {
                _player.settings.setMode("loop", value);
                _loop = value;
            }
        }

        public MusicPlayer()
        {
            Stop();
        }
        public MusicPlayer(string path)
        {
            Path = path;
            Stop();
        }

        public void Play() => _player.controls.play();
        public void Stop() => _player.controls.stop();
        public void Pause() => _player.controls.pause();
    }
}