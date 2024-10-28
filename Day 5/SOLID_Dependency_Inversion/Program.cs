namespace SOLID_Dependency_Inversion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Dependency inversion principle states that high levele module/classes
            // should not depend on low level modules/classes.
            // Both should depend upon abstraction(interface,abstract class)
            // Abstractions should not depend upon details but details should depend upon abstraction.

           var players = new Dictionary<string, IAudioPlayer>
           {
               {"MP3",new MP3Player() },
               {"WAV",new WAVPlayer() }
           };
           var musicPlayer = new MusicPlayer(players);
            musicPlayer.Play("song1.mp3", "MP3");
            musicPlayer.Play("song2.wav", "WAV");
            musicPlayer.Play("song3.mp4", "MP4");
            Console.ReadKey();
        }
    }
}
