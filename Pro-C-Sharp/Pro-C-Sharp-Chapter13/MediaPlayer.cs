using System;
using System.Collections.Generic;
using System.Text;

namespace Pro_C_Sharp_Chapter13
{
    public class MediaPlayer
    {
        // Assume these methods do something useful.
        public void Play() { /* Play a song */ }
        public void Pause() { /* Pause the song */ }
        public void Stop() { /* Stop playback */ }
        private Lazy<AllTracks> allSongs = new Lazy<AllTracks>();
        public AllTracks GetAllTracks()
        {
            // Return all of the songs.
            return allSongs.Value;
        }
    }
}
