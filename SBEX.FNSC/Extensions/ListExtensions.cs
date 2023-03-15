using SBEX.FNSC.Classes;
using System;
using System.Collections.Generic;

namespace SBEX.FNSC.Extensions
{
    public static class ListExtensions
    {
        private static Random rng = new Random();
        static bool ensureDiversity = true;
        public static void Shuffle<T>(this IList<T> list)
        {

            int n = list.Count;
            while (n > 1)
            {
                n--;

                int k = rng.Next(n + 1);
                int i = 0;
                if (ensureDiversity && typeof(Song).IsAssignableFrom(typeof(T)))
                {
                    Song song = list[k] as Song;
                    Song song2 = list[n] as Song;
                    while (song.UserId == song2.UserId)
                    {
                        i++;
                        k = rng.Next(n + 1);
                        song = list[k] as Song;
                        if (i == list.Count)
                        {
                            ensureDiversity = false;
                            break;
                        }
                    }
                }
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            ensureDiversity = true;
        }

        public static int VotingTime<T>(this IList<T> list)
        {
            int votingTime = 0;
            if (typeof(Match).IsAssignableFrom(typeof(T)))
                foreach (var item in list)
                {
                    votingTime += (item as Match).VotingTime;
                }
            return votingTime;
        }



    }

}
