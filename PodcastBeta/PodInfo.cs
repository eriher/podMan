using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace PodcastBeta
{
    public partial class PodInfo : UserControl
    {
        Podcast pod;
        FlowLayoutPanel playerPanel;
        public PodInfo(int pid)
        {
            pod = PodMan._download_serialized_json_data<Pod>("https://feedwrangler.net/api/v2/podcasts/show?podcast_id=" + pid).podcast;
            InitializeComponent();
            if(PodMan.Instance.SubscribedPods.Contains(pod))
                subscribed();  
            playerPanel = PodMan.Instance.PlayerContainer;
            podTitle.Text = pod.title;
            podSum.Text = pod.summary;
            podPic.ImageLocation = pod.image_url;
            podPic.LoadAsync(pod.image_url);
            foreach(Recent_Episodes ep in pod.recent_episodes)
            {
                podEpisodes.Rows.Add(ep.title);
            }
            podClose.Click += PodClose_Click;
        }

        private void PodClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void podEpisodes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PodMan.Instance.addToPlaylist(new Podcast { title = pod.title, summary = pod.summary, image_url = pod.image_url, podcast_id = pod.podcast_id, recent_episodes = new Recent_Episodes[] { pod.recent_episodes[podEpisodes.CurrentRow.Index] } });
        }

        private void podSub_Click(object sender, EventArgs e)
        {
            if (podSub.Text == "Subscribe")
            {
                PodMan.Instance.Subscribe(pod);
                subscribed();
            }
            else
            {
                PodMan.Instance.UnSubscribe(pod);
                unSubscribed();
            }
        }

        private void unSubscribed()
        {
            podSub.Text = "Subscribe";
            podSub.BackColor = Color.Transparent;
        }

        private void subscribed()
        {
            podSub.Text = "Subscribed";
            podSub.BackColor = Color.ForestGreen;
        }
    }
}
