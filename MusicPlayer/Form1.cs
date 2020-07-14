using CSCore.CoreAudioAPI;
using CSCore.SoundOut;
using Shell32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace MusicPlayer
{

    public partial class Main : Form
    {
        enum PlayMode
        {
            LoopOne,
            LoopList,
            Random
        }

        private int InitWidth = 0;
        private int CurrentPlayingIndex = -1;
        private string CurrentPlayingSong = "";
        private bool IsManualTrans = false;
        private bool IsLrcOn = false;
        private ListViewItem _Item;
        private ListViewItem _OldItem;
        private PlayMode CurrentPlayMode = PlayMode.Random;
        private Action<string, Label> SetLabelTextAction;
        private Action<double, PictureBox> SetTrackBarAction;
        FormLrc formLrc = new FormLrc();
        private ObservableCollection<MMDevice> _devices = new ObservableCollection<MMDevice>();
        private MusicPlayer _MusicPlayer = new MusicPlayer();
        private Timer RefreshUITime;
        private Timer RefreshUILrc;
        private Timer RefreshProgressBar;
        SortedDictionary<double, string> EachLrc = new SortedDictionary<double, string>();
        List<KeyValuePair<double, string>> LrcList = new List<KeyValuePair<double, string>>();
        private Dictionary<string, string> DicPath = new Dictionary<string, string>();
        public int index { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public string Duration { get; set; }


        private void SetTrackBar(double TotalTime, PictureBox _pic)
        {
            if (InvokeRequired)
            {

                SetTrackBarAction = SetTrackBar;
                try
                {
                    Invoke(SetTrackBarAction, TotalTime, _pic);
                }
                catch (Exception e)
                {
                    Application.Exit();
                }
            }
            else
            {
                if (_pic.Width > picBackBar.Width)
                    _pic.Width = picBackBar.Width;
                _pic.Width = (int)(picBackBar.Width / TotalTime * _MusicPlayer.Position.TotalSeconds);
            }
        }

        private void SetLabelText(string str, Label label)
        {
            if (InvokeRequired)
            {
                SetLabelTextAction = SetLabelText;
                try
                {
                    Invoke(SetLabelTextAction, str, label);
                }
                catch (Exception e)
                {
                    Application.Exit();
                }
              
            }
            else
            {
                label.Text = str;
            }
        }

        public Main()
        {
            InitializeComponent();
            MusicList.Columns.Add("歌曲名", -2, HorizontalAlignment.Left);
            MusicList.Columns.Add("歌手", -2, HorizontalAlignment.Left);
            MusicList.Columns.Add("专辑", -2, HorizontalAlignment.Left);
            MusicList.Columns.Add("时长", -2, HorizontalAlignment.Left);
            foreach (ColumnHeader column in MusicList.Columns)
            {
                column.Width = MusicList.Width / MusicList.Columns.Count;
            }

            GetDevices();
            index = 0;
            PicFrontBar.Size = new Size(0, PicFrontBar.Height);
            _MusicPlayer.PlaybackStopped += _MusicPlayer_PlaybackStopped;
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 50);
            MusicList.SmallImageList = imgList;
            InitWidth = LabelTitle.Width;
            PicShadow.SendToBack();
        }

        private void _MusicPlayer_PlaybackStopped(object sender, PlaybackStoppedEventArgs e)
        {
            if (IsManualTrans == false)
            {
                PlayNext();

            }
            IsManualTrans = false;
        }

        private void GetDevices()
        {
            var mmDeviceEnumerator = new MMDeviceEnumerator();
            var mmdeviceCollection = mmDeviceEnumerator.EnumAudioEndpoints(DataFlow.Render, DeviceState.Active);
            foreach (var device in mmdeviceCollection)
            {
                _devices.Add(device);
            }
        }

        private void PlayNext()
        {
            switch (CurrentPlayMode)
            {
                case PlayMode.LoopOne:
                    Play(MusicList.SelectedItems[0].Text);
                    break;
                case PlayMode.LoopList:
                    TransToNext();
                    break;
                case PlayMode.Random:
                    TransToRandomIndex();
                    break;

            }
        }

        private void GetLrcFromSong(string path)
        {
            EachLrc.Clear();
            LrcList.Clear();
            var file = TagLib.File.Create(path);
            string str = file.Tag.Lyrics;
            var RawLrc = str.Split('\n');
            foreach (var EachRawLrc in RawLrc)
            {
                if (string.IsNullOrEmpty(EachRawLrc) == false && EachRawLrc.IndexOf("[ar:") == -1 &&
                    EachRawLrc.IndexOf("[ti:") == -1 && EachRawLrc.IndexOf("[al:") == -1 &&
                    EachRawLrc.IndexOf("[by:") == -1)
                {
                    double FormatedTime = 0;
                    string SingleLrc = EachRawLrc;
                    var rawTimeBar = Regex.Matches(EachRawLrc, "\\[.*?\\]");
                    foreach (var EachTime in rawTimeBar)
                    {
                        double SingleMin = Convert.ToDouble(Regex.Match(EachTime.ToString(), "(?<=\\[).*(?=:)").Value);
                        double SingleSec = Convert.ToDouble(Regex.Match(EachTime.ToString(), "(?<=:).*?(?=\\])").Value);
                        FormatedTime = SingleMin * 60 + SingleSec;
                        SingleLrc = SingleLrc.Replace(EachTime.ToString(), "");
                    }

                    if (!EachLrc.ContainsKey(FormatedTime))
                    {
                        EachLrc.Add(FormatedTime, SingleLrc);
                    }

                }
            }
            LrcList = EachLrc.ToList();
        }

        private void SetAlbum(string path)
        {
            var file = TagLib.File.Create(path);
            if (file.Tag.Pictures.Length >= 1)
            {
                var bin = (byte[])(file.Tag.Pictures[0].Data.Data);
                AlbumPic.Image = Image.FromStream(new MemoryStream(bin))
                    .GetThumbnailImage(AlbumPic.Width, AlbumPic.Height, null, IntPtr.Zero);
            }
        }

        public void GetMusicTag(string path)
        {
            ShellClass sh = new ShellClass();
            Folder dir = sh.NameSpace(Path.GetDirectoryName(path)); //路径名
            FolderItem item = dir.ParseName(Path.GetFileName(path)); //文件名
            Name = dir.GetDetailsOf(item, 21);
            Artist = dir.GetDetailsOf(item, 13);
            Album = dir.GetDetailsOf(item, 14);
            Duration = dir.GetDetailsOf(item, 27);

        }


        private void Play(string MusicName)
        {
            string CurrentArtist = "";
            for (int i = 0; i < MusicList.Items.Count; i++)
            {
                if (MusicList.Items[i].SubItems[0].Text == MusicName)
                {
                    CurrentPlayingIndex = i;
                    CurrentArtist = MusicList.Items[i].SubItems[1].Text;
                }
            }
            SetUITitle(MusicName, CurrentArtist);
            CurrentPlayingSong = MusicName;
            _MusicPlayer.open(DicPath[MusicName], _devices[0]);
            _MusicPlayer.Play();
            CurrentPlayingSong = MusicName;
            //刷新时间显示
            RefreshUITime = new Timer(200);
            RefreshUITime.Elapsed += RefreshUITime_Elapsed;
            RefreshUITime.Start();
            SetAlbum(DicPath[MusicName]);
            GetLrcFromSong(DicPath[MusicName]);
            RefreshUILrc = new Timer(100);
            RefreshUILrc.Elapsed += RefreshUILrc_Elapsed;
            RefreshUILrc.Start();
            Image image = Properties.Resources.pause;
            PictureBoxPlay.Image = image;
            RefreshProgressBar = new Timer(800);
            RefreshProgressBar.Elapsed += RefreshProgressBar_Elapsed;
            RefreshProgressBar.Start();
        }


        private void RefreshProgressBar_Elapsed(object sender, ElapsedEventArgs e)
        {
            SetTrackBar(_MusicPlayer.Length.TotalSeconds, PicFrontBar);
        }

        //双击列表
        private void MusicList_DoubleClick(object sender, EventArgs e)
        {
            if (MusicList.SelectedItems.Count > 0)
            {
                CurrentPlayingIndex = MusicList.SelectedItems[0].Index;
                string MusicName = MusicList.Items[MusicList.SelectedItems[0].Index].Text;
                IsManualTrans = true;
                Play(MusicName);
                MusicList.Invalidate();
            }
        }

        private void SetUITitle(string title, string artist)
        {
            LabelTitle.Width = InitWidth;
            LabelTitle.Font = new Font("微软雅黑", 21);
            LabelTitle.Text = title;
            LabelArtist.Text = artist;
            float size = LabelTitle.Font.Size;
            LabelTitle.AutoSize = true;
            string content = LabelTitle.Text;
            while (LabelTitle.Width > InitWidth)
            {
                size -= 0.25F;
                LabelTitle.Font = new Font("微软雅黑", size);
            }
            LabelTitle.AutoSize = false;
        }
        //歌词同步
        private void RefreshUILrc_Elapsed(object sender, ElapsedEventArgs e)
        {
            double CurrentTime = _MusicPlayer.Position.TotalSeconds;
            for (int i = 0; i < LrcList.Count; i++)
            {
                try
                {
                    if (CurrentTime > LrcList[i].Key && CurrentTime < (LrcList[i + 1].Key))
                    {
                        SetLabelText(LrcList[i].Value, LabelLrc0);
                        SetTotalLrc(i);
                        FormLrc.StrLrc = LrcList[i].Value;
                    }
                }
                catch (Exception exception)
                {
                    SetLabelText(LrcList[LrcList.Count - 1].Value, LabelLrc0);
                    SetTotalLrc(LrcList.Count - 1);
                    FormLrc.StrLrc = LrcList[LrcList.Count - 1].Value;
                }

            }
        }

        private void SetTotalLrc(int pos)
        {
            string StrLrcNext = "";
            for (int i = 1; (LrcList.Count - pos - i > 0) && i < 11; i++)
            {
                StrLrcNext += LrcList[pos + i].Value + "\n";
            }
            SetLabelText(StrLrcNext, LrcNext);
        }
        //刷新UI
        private void RefreshUITime_Elapsed(object sender, ElapsedEventArgs e)
        {
            TimeSpan position = _MusicPlayer.Position;
            TimeSpan length = _MusicPlayer.Length;
            if (length.TotalSeconds != 0)
            {
                if (position > length)
                    length = position;
                if (length.TotalSeconds - position.TotalSeconds < 0.1)
                    IsManualTrans = false;
                SetLabelText($@"{position:mm\:ss} / {length:mm\:ss}", LabelTime);
            }

        }


        private void PictureBoxPlay_MouseHover(object sender, EventArgs e)
        {
            Image image = Properties.Resources.pause;
            if (_MusicPlayer.PlaybackState == PlaybackState.Playing)
            {
                PictureBoxPlay.Image = image;
                return;
            }

            image = Properties.Resources.play_20_s;
            PictureBoxPlay.Image = image;


        }

        private void PictureBoxPlay_MouseLeave(object sender, EventArgs e)
        {
            Image image = Properties.Resources.pause;
            if (_MusicPlayer.PlaybackState == PlaybackState.Playing)
            {
                PictureBoxPlay.Image = image;
                return;
            }

            image = Properties.Resources.play_20;
            PictureBoxPlay.Image = image;
        }

        private void PictureBoxPlay_Click(object sender, EventArgs e)
        {
            if (_MusicPlayer.PlaybackState == PlaybackState.Playing)
            {
                Image image = Properties.Resources.play_20_s;
                PictureBoxPlay.Image = image;
                _MusicPlayer.Pause();
                return;
            }

            if (_MusicPlayer.PlaybackState == PlaybackState.Paused)
            {
                Image image = Properties.Resources.pause;
                PictureBoxPlay.Image = image;
                _MusicPlayer.Play();
                return;
            }
        }

        private void PictureBox_Next_MouseHover(object sender, EventArgs e)
        {
            Image image = Properties.Resources.next_s;
            PictureBox_Next.Image = image;
        }

        private void PictureBox_Next_MouseLeave(object sender, EventArgs e)
        {
            Image image = Properties.Resources.next;
            PictureBox_Next.Image = image;
        }

        private void pictureBox_prev_MouseHover(object sender, EventArgs e)
        {
            Image image = Properties.Resources.prev_s;
            pictureBox_prev.Image = image;
        }

        private void pictureBox_prev_MouseLeave(object sender, EventArgs e)
        {
            Image image = Properties.Resources.prev;
            pictureBox_prev.Image = image;
        }

        private void pictureBox_prev_Click(object sender, EventArgs e)
        {
            TransToPrev();
            IsManualTrans = true;
        }

        private void TransToRandomIndex()
        {
            Random seed = new Random();
            int TempIndex = seed.Next(0, MusicList.Items.Count);
            Play(MusicList.Items[TempIndex].SubItems[0].Text);
            MusicList.Items[TempIndex].Selected = true;
            MusicList.Items[TempIndex].Focused = true;
            MusicList.Items[TempIndex].EnsureVisible();
            MusicList.Invalidate();
        }

        private void TransToPrev()
        {
            var SelectedCount = MusicList.SelectedItems.Count;
            if (MusicList.Items.Count == 0)
            {
                return;
            }

            if (CurrentPlayingIndex != -1)
            {
                if (CurrentPlayingIndex == 0)
                {
                    CurrentPlayingIndex = MusicList.Items.Count - 1;
                }
                else
                {
                    CurrentPlayingIndex--;
                }
            }
            else
            {
                CurrentPlayingIndex = 0;
            }
            MusicList.Items[CurrentPlayingIndex].Focused = true;
            MusicList.Items[CurrentPlayingIndex].Selected = true;
            MusicList.EnsureVisible(CurrentPlayingIndex);
            Play(MusicList.Items[CurrentPlayingIndex].Text);
            MusicList.Invalidate();
        }
        private void PictureBox_Next_Click(object sender, EventArgs e)
        {
            TransToNext();
            IsManualTrans = true;
        }

        private void TransToNext()
        {
            if (MusicList.Items.Count == 0)
            {
                return;
            }

            var SelectedCount = MusicList.SelectedItems.Count;
            if (CurrentPlayingIndex != -1)
            {
                if (CurrentPlayingIndex == MusicList.Items.Count - 1)
                {
                    CurrentPlayingIndex = 0;
                }
                else
                {
                    CurrentPlayingIndex++;
                }
            }
            else
            {
                CurrentPlayingIndex = 0;
            }
            MusicList.Items[CurrentPlayingIndex].Focused = true;
            MusicList.Items[CurrentPlayingIndex].Selected = true;
            MusicList.EnsureVisible(CurrentPlayingIndex);
            Play(MusicList.Items[CurrentPlayingIndex].Text);
            MusicList.Invalidate();
        }

        private void picBackBar_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Point xy = me.Location;
            double x = xy.X * _MusicPlayer.Length.TotalSeconds / picBackBar.Width;
            _MusicPlayer.Position = TimeSpan.FromSeconds(x);
        }

        private void PicFrontBar_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Point xy = me.Location;
            double x = xy.X * _MusicPlayer.Length.TotalSeconds / picBackBar.Width;
            _MusicPlayer.Position = TimeSpan.FromSeconds(x);
        }

        private void PicList_MouseHover(object sender, EventArgs e)
        {
            Image image = Properties.Resources.list_s;
            PicList.Image = image;
        }

        private void PicList_MouseLeave(object sender, EventArgs e)
        {
            Image image = Properties.Resources.list;
            PicList.Image = image;
        }

        private void PicList_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Multiselect = true;
            dlg.Filter = "媒体文件|*.mp3;*.wav;*.wma;*.avi;*.mpg;*.asf;*.wmv;*.flac";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                int subindex = 0;
                foreach (var path in dlg.FileNames)
                {
                    GetMusicTag(path);
                    if (!DicPath.ContainsKey(Name))
                    {
                        MusicList.Items.Add(Name);
                        MusicList.Items[MusicList.Items.Count - 1].SubItems.Add(Artist);
                        MusicList.Items[MusicList.Items.Count - 1].SubItems.Add(Album);
                        MusicList.Items[MusicList.Items.Count - 1].SubItems.Add(Duration);
                        DicPath.Add(Name, path);
                    }
                }

            }
        }

        private void LabelTime_Paint(object sender, PaintEventArgs e)
        {
            string str = LabelTime.Text;
            string strA = str.Substring(0, str.Length / 2);
            Point point = new Point(LabelTime.Padding.Left, LabelTime.Padding.Top);
            TextRenderer.DrawText(e.Graphics, strA, LabelTime.Font, point, Color.Black);
        }


        private void MusicList_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.Graphics.DrawString(e.Header.Text, new Font("微软雅黑", 12, FontStyle.Bold), Brushes.Black, new Rectangle(e.Bounds.X + 15,
                    e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
        }


        private void MusicList_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            if (e.Item.Selected)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(0, 120, 215)), new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, 50));
                e.Graphics.DrawString(e.SubItem.Text, new Font("微软雅黑", 10, FontStyle.Bold), Brushes.White,
                    new RectangleF(e.Bounds.X + 15, e.Bounds.Y + 15, e.Bounds.Width, 50));
            }
            else
            {
                if (e.ItemIndex % 2 == 0)
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(247, 247, 247)), new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, 50));
                }
                else
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.White), new Rectangle(e.Bounds.X + 15, e.Bounds.Y, e.Bounds.Width, 50));
                }

                string str = "";
                if (e.SubItem.Text.Length > 10)
                    str = e.SubItem.Text.Substring(0, 10) + ".....";
                else
                    str = e.SubItem.Text;
                if (e.ItemIndex == CurrentPlayingIndex)
                {
                    e.Graphics.DrawString(str, new Font("微软雅黑", 10), new SolidBrush(Color.FromArgb(0, 120, 215)),
                        new RectangleF(e.Bounds.X + 15, e.Bounds.Y + 15, e.Bounds.Width, 50));
                }
                else
                {
                    e.Graphics.DrawString(str, new Font("微软雅黑", 10), Brushes.Black,
                        new RectangleF(e.Bounds.X + 15, e.Bounds.Y + 15, e.Bounds.Width, 50));
                }

            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(CurrentPlayingSong);
        }
        private void PicPlayMode_MouseHover(object sender, EventArgs e)
        {
            if (CurrentPlayMode == PlayMode.Random)
            {
                Image image = Properties.Resources.random_s;
                PicPlayMode.Image = image;
                return;
            }
            if (CurrentPlayMode == PlayMode.LoopList)
            {
                Image image = Properties.Resources.looplist_s;
                PicPlayMode.Image = image;
                return;
            }
            if (CurrentPlayMode == PlayMode.LoopOne)
            {
                Image image = Properties.Resources.loopOne;
                PicPlayMode.Image = image;
            }
        }

        private void PicPlayMode_MouseLeave(object sender, EventArgs e)
        {
            if (CurrentPlayMode == PlayMode.Random)
            {
                Image image = Properties.Resources.random;
                PicPlayMode.Image = image;
                return;
            }
            if (CurrentPlayMode == PlayMode.LoopList)
            {
                Image image = Properties.Resources.looplist;
                PicPlayMode.Image = image;
                return;
            }
            if (CurrentPlayMode == PlayMode.LoopOne)
            {
                Image image = Properties.Resources.loopOne;
                PicPlayMode.Image = image;
            }
        }

        private void PicPlayMode_Click(object sender, EventArgs e)
        {
            if (CurrentPlayMode == PlayMode.Random)
            {
                CurrentPlayMode = PlayMode.LoopList;
                Image image = Properties.Resources.looplist_s;
                PicPlayMode.Image = image;
                return;
            }
            if (CurrentPlayMode == PlayMode.LoopList)
            {
                CurrentPlayMode = PlayMode.LoopOne;
                Image image = Properties.Resources.loopOne;
                PicPlayMode.Image = image;
                return;
            }
            if (CurrentPlayMode == PlayMode.LoopOne)
            {
                CurrentPlayMode = PlayMode.Random;
                Image image = Properties.Resources.random_s;
                PicPlayMode.Image = image;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            float size = LabelTitle.Font.Size;
            LabelTitle.AutoSize = true;
            string content = LabelTitle.Text;
            while (LabelTitle.Width > InitWidth)
            {
                size -= 0.25F;
                LabelTitle.Font = new Font("微软雅黑", size);
            }
            LabelTitle.AutoSize = false;
            InitWidth = LabelTitle.Width;

        }

        private void PicLrc_Click(object sender, EventArgs e)
        {
            if (IsLrcOn == false)
            {
                formLrc.Show();
                IsLrcOn = true;
                Image image = Properties.Resources.lrcTrue;
                PicLrc.Image = image;
                return;
            }
            if (IsLrcOn == true)
            {
                formLrc.Hide();
                IsLrcOn = false;
                Image image = Properties.Resources.LrcOff;
                PicLrc.Image = image;
            }
        }

        private void PicVolFront_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Point xy = me.Location;
            if (xy.X < 3)
            {
                PicVolFront.Width = 0;
                _MusicPlayer.volume = 0;
                LabelVolume.Text = "0";
                return;
            }
            if (xy.X > 98)
            {
                PicVolFront.Width = 100;
                _MusicPlayer.volume = 100;
                LabelVolume.Text = "100";
                return;
            }
            PicVolFront.Width = xy.X;
            _MusicPlayer.volume = xy.X;
            LabelVolume.Text = xy.X.ToString();
        }

        private void PicVolBack_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Point xy = me.Location;
            if (xy.X < 3)
            {
                PicVolFront.Width = 0;
                _MusicPlayer.volume = 0;
                LabelVolume.Text = "0";
                return;
            }
            if (xy.X > 98)
            {
                PicVolFront.Width = 100;
                _MusicPlayer.volume = 100;
                LabelVolume.Text = "100";
                return;
            }
            PicVolFront.Width = xy.X;
            _MusicPlayer.volume = xy.X;
            LabelVolume.Text = xy.X.ToString();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            _MusicPlayer.Stop();
            try
            {
                System.Environment.Exit(0);
            }
            catch (Exception exception)
            {

            }
           

        }

    }
}
