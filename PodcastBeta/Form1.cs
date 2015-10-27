using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Diagnostics;

namespace PodcastBeta
{
    public partial class Form1 : Form
    {
        Podlist pl;
        public Form1()
        {
            InitializeComponent();
            PodMan.Instance.PlayerContainer = flowLayoutPanel1;
            Sub_Init();
            Browse_Init();
            if (PodMan.Instance.SubscribedPods.Count == 0)
                tabControl1.SelectedIndex++;
            button1.BringToFront();
            mediaPlayer.PlayStateChange += MediaPlayer_PlayStateChange;
        }

        private void MediaPlayer_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            // Test the current state of the player and display a message for each state.
            switch (e.newState)
            {
                case 3:    // Playing
                    PodMan.Instance.updatePlayingInfo();
                    break;
                case 9:    // MediaEnded
                    PodMan.Instance.updatePlayingInfo();
                    break;
            }
        }

        private void Sub_Init()
        {
            pl = new Podlist("Subscribed Pods", PodMan.Instance.SubscribedPods.ToArray(), false);
            tabPage1.Controls.Add(pl);
        }
        private void Browse_Init()
        {
            Pods cat = PodMan._download_serialized_json_data<Pods>("https://feedwrangler.net/api/v2/podcasts/categories");
            foreach (Podcast p in cat.podcasts)
            {
                Button button = new Button();
                button.Text = p.title;
                button.Tag = p;
                button.Width = 220;
                button.Height = 100;
                button.Click += new EventHandler(button_Click);
                flowLayoutPanel3.Controls.Add(button);

            }
        }
        private void button_Click(object sender, EventArgs e)
        {

            var btn = sender as Button;
            Pods topInCat;
            if (btn != null)
            {
                var pod = btn.Tag as Podcast;
                if (pod != null)
                {
                    topInCat = PodMan._download_serialized_json_data<Pods>("https://feedwrangler.net/api/v2/podcasts/category?id=" + pod.category_id);
                    topInCat.podcasts = topInCat.podcasts.Where(x => !string.IsNullOrEmpty(x.image_url)).ToArray();
                    Podlist pl = new Podlist(btn.Text, topInCat.podcasts, true);
                    //panel1.Controls.Clear();
                    //panel1.Controls.Add(uc);
                    tabPage2.Controls.Add(pl);
                    pl.BringToFront();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pl.Dispose();
            Sub_Init();
        }

        private void playlist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PodMan.Instance.startMediaPlay(playlist.CurrentRow.Index);
        }

        private void playingPic_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
            PodInfo uc = new PodInfo(PodMan.Instance.getPlaying().podcast_id);
            tabPage1.Controls.Add(uc);
            uc.BringToFront();
        }
    }
}
