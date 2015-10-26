using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodcastBeta
{
    public class Pods
    {
        public object error { get; set; }
        public string result { get; set; }
        public int count { get; set; }
        public Podcast[] podcasts { get; set; }
    }
}
