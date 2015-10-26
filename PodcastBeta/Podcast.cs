using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodcastBeta
{
    public class Podcast
    {
        public string title { get; set; }
        public int podcast_id { get; set; }
        public string image_url { get; set; }
        public string feed_url { get; set; }
        public string podcasts_url { get; set; }
        public int category_id { get; set; }
        public Recent_Episodes[] recent_episodes { get; set; }
        public string summary { get; set; }

        public override bool Equals(System.Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            Podcast p = obj as Podcast;
            if ((System.Object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (podcast_id == p.podcast_id);

        }
        public override int GetHashCode()
        {
            return podcast_id ^ title.GetHashCode();
        }
    }
}