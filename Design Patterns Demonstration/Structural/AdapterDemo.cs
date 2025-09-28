using System;

namespace DesignPatternsDemo.Structural
{
    public interface IMediaPlayer { void Play(string filename); }
    public class Mp3Player : IMediaPlayer { public void Play(string f) => Console.WriteLine($"Playing MP3: {f}"); }
    public class Mp4Player { public void PlayMp4(string f) => Console.WriteLine($"Playing MP4: {f}"); }

    public class MediaAdapter : IMediaPlayer
    {
        private Mp4Player mp4 = new();
        public void Play(string f) => mp4.PlayMp4(f);
    }

    public static class AdapterDemo
    {
        public static void Run()
        {
            Console.WriteLine("\n--- Adapter Pattern Demo ---");
            IMediaPlayer player1 = new Mp3Player();
            IMediaPlayer player2 = new MediaAdapter();
            player1.Play("song.mp3");
            player2.Play("video.mp4");
        }
    }
}
