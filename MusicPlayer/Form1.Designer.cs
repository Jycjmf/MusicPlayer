namespace MusicPlayer
{
    partial class Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.MusicList = new System.Windows.Forms.ListView();
            this.LabelTime = new System.Windows.Forms.Label();
            this.LabelLrc0 = new System.Windows.Forms.Label();
            this.LrcNext = new System.Windows.Forms.Label();
            this.LabelTitle = new System.Windows.Forms.Label();
            this.LabelArtist = new System.Windows.Forms.Label();
            this.LabelVolume = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PicShadow = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PicVolFront = new System.Windows.Forms.PictureBox();
            this.PicVolBack = new System.Windows.Forms.PictureBox();
            this.PicSound = new System.Windows.Forms.PictureBox();
            this.PicLrc = new System.Windows.Forms.PictureBox();
            this.PicPlayMode = new System.Windows.Forms.PictureBox();
            this.PicList = new System.Windows.Forms.PictureBox();
            this.PicFrontBar = new System.Windows.Forms.PictureBox();
            this.picBackBar = new System.Windows.Forms.PictureBox();
            this.pictureBox_prev = new System.Windows.Forms.PictureBox();
            this.PictureBox_Next = new System.Windows.Forms.PictureBox();
            this.PictureBoxPlay = new System.Windows.Forms.PictureBox();
            this.AlbumPic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PicShadow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicVolFront)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicVolBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicSound)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicLrc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicPlayMode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicFrontBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_prev)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Next)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxPlay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlbumPic)).BeginInit();
            this.SuspendLayout();
            // 
            // MusicList
            // 
            this.MusicList.AutoArrange = false;
            this.MusicList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MusicList.FullRowSelect = true;
            this.MusicList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.MusicList.HideSelection = false;
            this.MusicList.Location = new System.Drawing.Point(353, 48);
            this.MusicList.MultiSelect = false;
            this.MusicList.Name = "MusicList";
            this.MusicList.OwnerDraw = true;
            this.MusicList.Size = new System.Drawing.Size(904, 554);
            this.MusicList.TabIndex = 2;
            this.MusicList.UseCompatibleStateImageBehavior = false;
            this.MusicList.View = System.Windows.Forms.View.Details;
            this.MusicList.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.MusicList_DrawColumnHeader);
            this.MusicList.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.MusicList_DrawSubItem);
            this.MusicList.DoubleClick += new System.EventHandler(this.MusicList_DoubleClick);
            // 
            // LabelTime
            // 
            this.LabelTime.AutoSize = true;
            this.LabelTime.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LabelTime.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.LabelTime.Location = new System.Drawing.Point(333, 671);
            this.LabelTime.Name = "LabelTime";
            this.LabelTime.Size = new System.Drawing.Size(107, 21);
            this.LabelTime.TabIndex = 6;
            this.LabelTime.Text = "00:00 / 00:00";
            this.LabelTime.Paint += new System.Windows.Forms.PaintEventHandler(this.LabelTime_Paint);
            // 
            // LabelLrc0
            // 
            this.LabelLrc0.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LabelLrc0.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.LabelLrc0.Location = new System.Drawing.Point(25, 344);
            this.LabelLrc0.Name = "LabelLrc0";
            this.LabelLrc0.Size = new System.Drawing.Size(292, 34);
            this.LabelLrc0.TabIndex = 0;
            this.LabelLrc0.Text = "None Music";
            this.LabelLrc0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LrcNext
            // 
            this.LrcNext.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LrcNext.Location = new System.Drawing.Point(25, 372);
            this.LrcNext.Name = "LrcNext";
            this.LrcNext.Size = new System.Drawing.Size(292, 248);
            this.LrcNext.TabIndex = 20;
            this.LrcNext.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LabelTitle
            // 
            this.LabelTitle.Font = new System.Drawing.Font("微软雅黑", 21F);
            this.LabelTitle.Location = new System.Drawing.Point(78, 649);
            this.LabelTitle.Name = "LabelTitle";
            this.LabelTitle.Size = new System.Drawing.Size(237, 33);
            this.LabelTitle.TabIndex = 21;
            this.LabelTitle.Text = "Title";
            // 
            // LabelArtist
            // 
            this.LabelArtist.AutoEllipsis = true;
            this.LabelArtist.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LabelArtist.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.LabelArtist.Location = new System.Drawing.Point(81, 687);
            this.LabelArtist.Name = "LabelArtist";
            this.LabelArtist.Size = new System.Drawing.Size(237, 33);
            this.LabelArtist.TabIndex = 23;
            this.LabelArtist.Text = "Artist";
            // 
            // LabelVolume
            // 
            this.LabelVolume.AutoSize = true;
            this.LabelVolume.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LabelVolume.Location = new System.Drawing.Point(1138, 670);
            this.LabelVolume.Name = "LabelVolume";
            this.LabelVolume.Size = new System.Drawing.Size(37, 21);
            this.LabelVolume.TabIndex = 26;
            this.LabelVolume.Text = "100";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 19F);
            this.label1.Location = new System.Drawing.Point(11, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 35);
            this.label1.TabIndex = 31;
            this.label1.Text = "当前";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 19F);
            this.label2.Location = new System.Drawing.Point(347, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 35);
            this.label2.TabIndex = 32;
            this.label2.Text = "曲库";
            // 
            // PicShadow
            // 
            this.PicShadow.Image = global::MusicPlayer.Properties.Resources.未标题_2;
            this.PicShadow.Location = new System.Drawing.Point(11, 26);
            this.PicShadow.Name = "PicShadow";
            this.PicShadow.Size = new System.Drawing.Size(320, 315);
            this.PicShadow.TabIndex = 33;
            this.PicShadow.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox1.Location = new System.Drawing.Point(333, 48);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(2, 550);
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
            // 
            // PicVolFront
            // 
            this.PicVolFront.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.PicVolFront.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PicVolFront.Location = new System.Drawing.Point(1027, 677);
            this.PicVolFront.Name = "PicVolFront";
            this.PicVolFront.Size = new System.Drawing.Size(100, 6);
            this.PicVolFront.TabIndex = 29;
            this.PicVolFront.TabStop = false;
            this.PicVolFront.Click += new System.EventHandler(this.PicVolFront_Click);
            // 
            // PicVolBack
            // 
            this.PicVolBack.BackColor = System.Drawing.SystemColors.ControlLight;
            this.PicVolBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PicVolBack.Location = new System.Drawing.Point(1027, 677);
            this.PicVolBack.Name = "PicVolBack";
            this.PicVolBack.Size = new System.Drawing.Size(100, 6);
            this.PicVolBack.TabIndex = 28;
            this.PicVolBack.TabStop = false;
            this.PicVolBack.Click += new System.EventHandler(this.PicVolBack_Click);
            // 
            // PicSound
            // 
            this.PicSound.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PicSound.Image = global::MusicPlayer.Properties.Resources.sound;
            this.PicSound.InitialImage = null;
            this.PicSound.Location = new System.Drawing.Point(985, 666);
            this.PicSound.Name = "PicSound";
            this.PicSound.Size = new System.Drawing.Size(30, 30);
            this.PicSound.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PicSound.TabIndex = 25;
            this.PicSound.TabStop = false;
            // 
            // PicLrc
            // 
            this.PicLrc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PicLrc.Image = global::MusicPlayer.Properties.Resources.LrcOff;
            this.PicLrc.InitialImage = null;
            this.PicLrc.Location = new System.Drawing.Point(772, 666);
            this.PicLrc.Name = "PicLrc";
            this.PicLrc.Size = new System.Drawing.Size(30, 30);
            this.PicLrc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PicLrc.TabIndex = 24;
            this.PicLrc.TabStop = false;
            this.PicLrc.Click += new System.EventHandler(this.PicLrc_Click);
            // 
            // PicPlayMode
            // 
            this.PicPlayMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PicPlayMode.Image = global::MusicPlayer.Properties.Resources.random;
            this.PicPlayMode.InitialImage = null;
            this.PicPlayMode.Location = new System.Drawing.Point(718, 666);
            this.PicPlayMode.Name = "PicPlayMode";
            this.PicPlayMode.Size = new System.Drawing.Size(30, 30);
            this.PicPlayMode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PicPlayMode.TabIndex = 19;
            this.PicPlayMode.TabStop = false;
            this.PicPlayMode.Click += new System.EventHandler(this.PicPlayMode_Click);
            this.PicPlayMode.MouseLeave += new System.EventHandler(this.PicPlayMode_MouseLeave);
            this.PicPlayMode.MouseHover += new System.EventHandler(this.PicPlayMode_MouseHover);
            // 
            // PicList
            // 
            this.PicList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PicList.Image = ((System.Drawing.Image)(resources.GetObject("PicList.Image")));
            this.PicList.InitialImage = null;
            this.PicList.Location = new System.Drawing.Point(502, 666);
            this.PicList.Name = "PicList";
            this.PicList.Size = new System.Drawing.Size(30, 30);
            this.PicList.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PicList.TabIndex = 18;
            this.PicList.TabStop = false;
            this.PicList.Click += new System.EventHandler(this.PicList_Click);
            this.PicList.MouseLeave += new System.EventHandler(this.PicList_MouseLeave);
            this.PicList.MouseHover += new System.EventHandler(this.PicList_MouseHover);
            // 
            // PicFrontBar
            // 
            this.PicFrontBar.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.PicFrontBar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PicFrontBar.Location = new System.Drawing.Point(1, 630);
            this.PicFrontBar.Name = "PicFrontBar";
            this.PicFrontBar.Size = new System.Drawing.Size(29, 6);
            this.PicFrontBar.TabIndex = 16;
            this.PicFrontBar.TabStop = false;
            this.PicFrontBar.Click += new System.EventHandler(this.PicFrontBar_Click);
            // 
            // picBackBar
            // 
            this.picBackBar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.picBackBar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBackBar.Location = new System.Drawing.Point(1, 630);
            this.picBackBar.Name = "picBackBar";
            this.picBackBar.Size = new System.Drawing.Size(1314, 6);
            this.picBackBar.TabIndex = 15;
            this.picBackBar.TabStop = false;
            this.picBackBar.Click += new System.EventHandler(this.picBackBar_Click);
            // 
            // pictureBox_prev
            // 
            this.pictureBox_prev.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_prev.Image = global::MusicPlayer.Properties.Resources.prev;
            this.pictureBox_prev.InitialImage = null;
            this.pictureBox_prev.Location = new System.Drawing.Point(556, 666);
            this.pictureBox_prev.Name = "pictureBox_prev";
            this.pictureBox_prev.Size = new System.Drawing.Size(30, 30);
            this.pictureBox_prev.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox_prev.TabIndex = 14;
            this.pictureBox_prev.TabStop = false;
            this.pictureBox_prev.Click += new System.EventHandler(this.pictureBox_prev_Click);
            this.pictureBox_prev.MouseLeave += new System.EventHandler(this.pictureBox_prev_MouseLeave);
            this.pictureBox_prev.MouseHover += new System.EventHandler(this.pictureBox_prev_MouseHover);
            // 
            // PictureBox_Next
            // 
            this.PictureBox_Next.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureBox_Next.Image = global::MusicPlayer.Properties.Resources.next;
            this.PictureBox_Next.InitialImage = null;
            this.PictureBox_Next.Location = new System.Drawing.Point(664, 666);
            this.PictureBox_Next.Name = "PictureBox_Next";
            this.PictureBox_Next.Size = new System.Drawing.Size(30, 30);
            this.PictureBox_Next.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PictureBox_Next.TabIndex = 13;
            this.PictureBox_Next.TabStop = false;
            this.PictureBox_Next.Click += new System.EventHandler(this.PictureBox_Next_Click);
            this.PictureBox_Next.MouseLeave += new System.EventHandler(this.PictureBox_Next_MouseLeave);
            this.PictureBox_Next.MouseHover += new System.EventHandler(this.PictureBox_Next_MouseHover);
            // 
            // PictureBoxPlay
            // 
            this.PictureBoxPlay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureBoxPlay.Image = global::MusicPlayer.Properties.Resources.play_20;
            this.PictureBoxPlay.InitialImage = null;
            this.PictureBoxPlay.Location = new System.Drawing.Point(610, 666);
            this.PictureBoxPlay.Name = "PictureBoxPlay";
            this.PictureBoxPlay.Size = new System.Drawing.Size(30, 30);
            this.PictureBoxPlay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PictureBoxPlay.TabIndex = 12;
            this.PictureBoxPlay.TabStop = false;
            this.PictureBoxPlay.Click += new System.EventHandler(this.PictureBoxPlay_Click);
            this.PictureBoxPlay.MouseLeave += new System.EventHandler(this.PictureBoxPlay_MouseLeave);
            this.PictureBoxPlay.MouseHover += new System.EventHandler(this.PictureBoxPlay_MouseHover);
            // 
            // AlbumPic
            // 
            this.AlbumPic.Image = ((System.Drawing.Image)(resources.GetObject("AlbumPic.Image")));
            this.AlbumPic.Location = new System.Drawing.Point(26, 48);
            this.AlbumPic.Name = "AlbumPic";
            this.AlbumPic.Size = new System.Drawing.Size(290, 276);
            this.AlbumPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.AlbumPic.TabIndex = 9;
            this.AlbumPic.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1313, 737);
            this.Controls.Add(this.PicShadow);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.PicVolFront);
            this.Controls.Add(this.PicVolBack);
            this.Controls.Add(this.LabelVolume);
            this.Controls.Add(this.PicSound);
            this.Controls.Add(this.PicLrc);
            this.Controls.Add(this.LabelArtist);
            this.Controls.Add(this.LabelTitle);
            this.Controls.Add(this.LrcNext);
            this.Controls.Add(this.LabelLrc0);
            this.Controls.Add(this.PicPlayMode);
            this.Controls.Add(this.PicList);
            this.Controls.Add(this.PicFrontBar);
            this.Controls.Add(this.picBackBar);
            this.Controls.Add(this.pictureBox_prev);
            this.Controls.Add(this.PictureBox_Next);
            this.Controls.Add(this.PictureBoxPlay);
            this.Controls.Add(this.AlbumPic);
            this.Controls.Add(this.LabelTime);
            this.Controls.Add(this.MusicList);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.ShowIcon = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.PicShadow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicVolFront)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicVolBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicSound)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicLrc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicPlayMode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicFrontBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_prev)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Next)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxPlay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlbumPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView MusicList;
        private System.Windows.Forms.Label LabelTime;
        private System.Windows.Forms.PictureBox AlbumPic;
        private System.Windows.Forms.PictureBox PictureBoxPlay;
        private System.Windows.Forms.PictureBox PictureBox_Next;
        private System.Windows.Forms.PictureBox pictureBox_prev;
        private System.Windows.Forms.PictureBox picBackBar;
        private System.Windows.Forms.PictureBox PicFrontBar;
        private System.Windows.Forms.PictureBox PicList;
        private System.Windows.Forms.PictureBox PicPlayMode;
        private System.Windows.Forms.Label LabelLrc0;
        private System.Windows.Forms.Label LrcNext;
        private System.Windows.Forms.Label LabelTitle;
        private System.Windows.Forms.Label LabelArtist;
        private System.Windows.Forms.PictureBox PicLrc;
        private System.Windows.Forms.PictureBox PicSound;
        private System.Windows.Forms.Label LabelVolume;
        private System.Windows.Forms.PictureBox PicVolBack;
        private System.Windows.Forms.PictureBox PicVolFront;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox PicShadow;
    }
}

