namespace PodcastBeta
{
    partial class PodInfo
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.podSub = new System.Windows.Forms.Button();
            this.podEpisodes = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.podSum = new System.Windows.Forms.TextBox();
            this.podPic = new System.Windows.Forms.PictureBox();
            this.podClose = new System.Windows.Forms.Button();
            this.podTitle = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.podEpisodes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.podPic)).BeginInit();
            this.SuspendLayout();
            // 
            // podSub
            // 
            this.podSub.Location = new System.Drawing.Point(11, 12);
            this.podSub.Name = "podSub";
            this.podSub.Size = new System.Drawing.Size(92, 31);
            this.podSub.TabIndex = 9;
            this.podSub.Text = "Subscribe";
            this.podSub.UseVisualStyleBackColor = true;
            this.podSub.Click += new System.EventHandler(this.podSub_Click);
            // 
            // podEpisodes
            // 
            this.podEpisodes.AllowUserToAddRows = false;
            this.podEpisodes.AllowUserToDeleteRows = false;
            this.podEpisodes.AllowUserToResizeColumns = false;
            this.podEpisodes.AllowUserToResizeRows = false;
            this.podEpisodes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.podEpisodes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.podEpisodes.Location = new System.Drawing.Point(11, 318);
            this.podEpisodes.MultiSelect = false;
            this.podEpisodes.Name = "podEpisodes";
            this.podEpisodes.ReadOnly = true;
            this.podEpisodes.RowHeadersVisible = false;
            this.podEpisodes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.podEpisodes.Size = new System.Drawing.Size(684, 280);
            this.podEpisodes.TabIndex = 8;
            this.podEpisodes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.podEpisodes_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.DividerWidth = 2;
            this.Column1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Column1.HeaderText = "Episode";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // podSum
            // 
            this.podSum.Enabled = false;
            this.podSum.Location = new System.Drawing.Point(221, 112);
            this.podSum.Multiline = true;
            this.podSum.Name = "podSum";
            this.podSum.Size = new System.Drawing.Size(474, 200);
            this.podSum.TabIndex = 7;
            // 
            // podPic
            // 
            this.podPic.Location = new System.Drawing.Point(11, 112);
            this.podPic.Name = "podPic";
            this.podPic.Size = new System.Drawing.Size(200, 200);
            this.podPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.podPic.TabIndex = 5;
            this.podPic.TabStop = false;
            // 
            // podClose
            // 
            this.podClose.Location = new System.Drawing.Point(603, 12);
            this.podClose.Name = "podClose";
            this.podClose.Size = new System.Drawing.Size(92, 31);
            this.podClose.TabIndex = 10;
            this.podClose.Text = "Close";
            this.podClose.UseVisualStyleBackColor = true;
            // 
            // podTitle
            // 
            this.podTitle.BackColor = System.Drawing.Color.White;
            this.podTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.podTitle.Enabled = false;
            this.podTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.podTitle.Location = new System.Drawing.Point(11, 49);
            this.podTitle.Multiline = true;
            this.podTitle.Name = "podTitle";
            this.podTitle.Size = new System.Drawing.Size(684, 57);
            this.podTitle.TabIndex = 11;
            // 
            // PodInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.podTitle);
            this.Controls.Add(this.podClose);
            this.Controls.Add(this.podSub);
            this.Controls.Add(this.podEpisodes);
            this.Controls.Add(this.podSum);
            this.Controls.Add(this.podPic);
            this.Name = "PodInfo";
            this.Size = new System.Drawing.Size(712, 622);
            ((System.ComponentModel.ISupportInitialize)(this.podEpisodes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.podPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button podSub;
        private System.Windows.Forms.DataGridView podEpisodes;
        private System.Windows.Forms.DataGridViewButtonColumn Column1;
        private System.Windows.Forms.TextBox podSum;
        private System.Windows.Forms.PictureBox podPic;
        private System.Windows.Forms.Button podClose;
        private System.Windows.Forms.TextBox podTitle;
    }
}
