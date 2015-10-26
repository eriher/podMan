using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PodcastBeta
{
    public partial class Podlist : UserControl
    {
        int currentIndex = 0;
        Podcast[] pods;
        string title;
        public Podlist(string title, Podcast[] pods, bool close)
        {
            InitializeComponent();
            this.pods = pods;
            this.title = title;
            btnClose.Click += BtnClose_Click;
            btnNext.Click += BtnNext_Click;
            btnPrev.Click += BtnPrev_Click;
            PopList(0);
            if(!close)
                btnClose.Hide();
        }

        private void BtnPrev_Click(object sender, EventArgs e)
        {
            PopList(-1);
            if (!btnNext.Enabled)
                btnNext.Enabled = true;
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            PopList(1);
            if(!btnPrev.Enabled)
                btnPrev.Enabled = true;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        public void PopList(int direction)
        {
            flowList.Controls.Clear();
            if (direction == -1)
            {
                currentIndex = -12;
                if (currentIndex < 0)
                    currentIndex = 0;
                if (currentIndex == 0)
                    btnPrev.Enabled = false;
            }
            else if (direction == 0)
                currentIndex = 0;
            catTitle.Text = (currentIndex+1) + "-"+(currentIndex + 12) + " pods in " + title;
            int nItems = 12+currentIndex;
            if (nItems > pods.Length)
            {
                nItems = pods.Length;
                btnNext.Enabled = false;
            }
            for (int i = currentIndex; i < nItems; i++)
            {
                GroupBox gb = new GroupBox();
                gb.Text = pods[i].title;
                gb.Height = 170;
                gb.Width = 170;
                PictureBox pic = new PictureBox();
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pic.ImageLocation = pods[i].image_url;
                pic.LoadAsync(pods[i].image_url);
                pic.Dock = DockStyle.Fill;
                pic.MouseClick += Pic_MouseClick;
                pic.Tag = pods[i];
                gb.Controls.Add(pic);
                ToolTip toolTip1 = new ToolTip();
                toolTip1.SetToolTip(pic, pods[i].title);
                flowList.Controls.Add(gb);
                currentIndex++;
            }
        }

        private void Pic_MouseClick(object sender, MouseEventArgs e)
        {
            PodInfo uc = new PodInfo(((sender as PictureBox).Tag as Podcast).podcast_id);
            //panel1.Controls.Clear();
            //panel1.Controls.Add(uc);
            this.Parent.Controls.Add(uc);
            uc.BringToFront();
        }
    }
}
