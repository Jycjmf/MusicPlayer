using CSCore;
using CSCore.Codecs;
using CSCore.CoreAudioAPI;
using CSCore.SoundOut;
using System;
using System.ComponentModel;

namespace MusicPlayer
{
    class MusicPlayer : Component
    {
        private ISoundOut _SoundOut;
        private IWaveSource _WaveSource;
        public event EventHandler<PlaybackStoppedEventArgs> PlaybackStopped;
        public PlaybackState PlaybackState
        {
            get
            {
                if (_SoundOut != null)
                    return _SoundOut.PlaybackState;
                return PlaybackState.Stopped;
            }
        }

        public TimeSpan Position
        {
            get
            {
                if (_WaveSource != null)
                    return _WaveSource.GetPosition();
                return TimeSpan.Zero;
            }
            set
            {
                if (_WaveSource != null)
                    _WaveSource.SetPosition(value);
            }
        }

        public TimeSpan Length
        {
            get
            {
                if (_WaveSource != null)
                    return _WaveSource.GetLength();
                return TimeSpan.Zero;
            }
        }

        public int volume
        {
            get
            {
                if (_SoundOut != null)
                    return Math.Min(100, Math.Max(0, (int)(_SoundOut.Volume * 100)));
                return 100;
            }
            set
            {
                if (_SoundOut != null)
                    _SoundOut.Volume = Math.Min(1.0f, Math.Max(0f, value / 100f));
            }
        }

        private void CleanupPlayback()
        {
            if (_SoundOut != null)
            {
                _SoundOut.Dispose();
                _SoundOut = null;
            }

            if (_WaveSource != null)
            {
                _WaveSource.Dispose();
                _WaveSource = null;
            }
        }

        public void open(string path, MMDevice device)
        {
            CleanupPlayback();
            _WaveSource = CodecFactory.Instance.GetCodec(path);
            _SoundOut = new WasapiOut() { Latency = 500, Device = device };
            _SoundOut.Initialize(_WaveSource);
            if (PlaybackStopped != null) _SoundOut.Stopped += PlaybackStopped;
        }

        public void Play()
        {
            if (_SoundOut != null)
                _SoundOut.Play();
        }

        public void Pause()
        {
            if (_SoundOut != null)
                _SoundOut.Pause();
        }

        public void Stop()
        {
            if (_SoundOut != null)
                _SoundOut.Stop();
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            CleanupPlayback();
            
        }
    }
}