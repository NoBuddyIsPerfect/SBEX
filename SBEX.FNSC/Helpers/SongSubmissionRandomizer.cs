using SBEX.FNSC.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBEX.FNSC.Helpers
{
    public static class SongRandomizer
    {    
        private static Random random = new Random();
        public static ThreadedBindingList<Song> RandomizeSongs(List<Song> songSubmissions)
        {
            ThreadedBindingList<Song> randomizedSubmissions = new ThreadedBindingList<Song>();

            List<Song> shuffledSubmissions = songSubmissions.OrderBy(x => random.Next()).ToList();

            string previousUserId = string.Empty;
            string previousArtist = string.Empty;

            foreach (Song song in shuffledSubmissions)
            {
                if (song.UserId != previousUserId)// && song.Artist != previousArtist)
                {
                    randomizedSubmissions.Add(song);
                    previousUserId = song.UserId;
                    previousArtist = song.Artist;
                }
                else
                {
                    Song newSong = FindNewSong(songSubmissions, randomizedSubmissions, previousUserId, previousArtist);

                    if (newSong != null)
                    {
                        randomizedSubmissions.Add(newSong);
                        previousUserId = newSong.UserId;
                        previousArtist = newSong.Artist;
                    }
                }
            }

            return randomizedSubmissions;
        }

        private static Song FindNewSong(List<Song> songSubmissions, ThreadedBindingList<Song> randomizedSubmissions, string previousUserId, string previousArtist)
        {
            List<Song> remainingSubmissions = songSubmissions.Except(randomizedSubmissions).ToList();

            foreach (Song song in remainingSubmissions)
            {
                if (song.UserId != previousUserId)// && song.Artist != previousArtist)
                {
                    return song;
                }
            }

            return null;
        }
    }
}
