using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace MusicPlayer
{
    public partial class FormLrc : Form
    {
        public static string StrLrc="";
        private Timer RefreshLrc;
        [DllImport("User32.dll", SetLastError = true)]
        public static extern int SendMessageTimeout(IntPtr hWnd, uint uMsg, uint wParam, StringBuilder lParam, uint fuFlags, uint uTimeout, IntPtr lpdwResult);
        [DllImport("user32.dll", EntryPoint = "GetWindowLong")]
        public static extern Int32 GetWindowLong(IntPtr hwnd, int nIndex);
        [DllImport("user32.dll", EntryPoint = "SetWindowLong")]
        public static extern Int32 SetWindowLong(IntPtr hwnd, int nIndex, Int32 dwNewLong);
        [DllImport("user32", EntryPoint = "SetLayeredWindowAttributes")]
        public static extern int SetLayeredWindowAttributes(IntPtr Handle, int crKey, byte bAlpha, int dwFlags);
        const int GWL_EXSTYLE = -20;
        const int WS_EX_TRANSPARENT = 0x20;
        const int WS_EX_LAYERED = 0x80000;
        const int LWA_ALPHA = 2;
        private const int LWA_COLORKEY = 0x1;
        [DllImport("user32.dll", EntryPoint = "FindWindowEx", SetLastError = true)]
        static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        [DllImport("user32.dll", EntryPoint = "SetParent")]
        static extern int SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        [DllImport("user32.dll")]
        static extern bool GetWindowRect(IntPtr hWnd, ref Rectangle lpRect);
        [DllImport("user32.dll")]
        static extern bool MoveWindow(IntPtr hWnd, int x, int y, int nWidth, int nHeight, bool BRePaint);
        public FormLrc()
        {
            InitializeComponent();
        }
        public int GetRGBFromColor(Color color)
        {
            byte r = color.R;
            byte g = color.G;
            byte b = color.B;
            //转化为32bit RGB值:
            int rgb = (r & 0xff) | ((g & 0xff) << 8) | ((b & 0xff) << 16);
            return rgb;
        }

        private void FormLrc_Load(object sender, EventArgs e)
        {
            StringBuilder srebuild=new StringBuilder("TraySettings");
            SendMessageTimeout((IntPtr)0xffff, 0x001A, 0, srebuild, 0x0008, 3000, IntPtr.Zero);//切换任务栏图标大小强制复位尺寸
            LabelLrc.TextAlign = ContentAlignment.MiddleRight;
            var hShell = FindWindowEx(IntPtr.Zero, IntPtr.Zero, "Shell_TrayWnd", null);//整个任务栏
            var hBar = FindWindowEx(hShell, IntPtr.Zero, "ReBarWindow32", null);//二级容器
            var hMin = FindWindowEx(hBar, IntPtr.Zero, "MSTaskSwWClass", null);//最小化区域
            Rectangle rcShell = new Rectangle();//整个任务栏
            Rectangle rcBar = new Rectangle();//二级容器
            Rectangle rcMin = new Rectangle();//最小化区域
            GetWindowRect(hShell, ref rcShell);
            GetWindowRect(hBar, ref rcBar);
            GetWindowRect(hMin, ref rcMin);
            MoveWindow(hMin, 0, 0, rcMin.Width - rcMin.X - this.Width, rcMin.Height - rcMin.Y, true);//缩小最小化区域
            GetWindowRect(hMin, ref rcMin);
            SetWindowLong(this.Handle, GWL_EXSTYLE, GetWindowLong(Handle, GWL_EXSTYLE) | WS_EX_LAYERED);
            SetParent(this.Handle, hBar);
            SetLayeredWindowAttributes(this.Handle, GetRGBFromColor(Color.Black), 255, LWA_COLORKEY);
            var OutTaskBarSize = new Size(SystemInformation.WorkingArea.Width, SystemInformation.WorkingArea.Height);
            var ScreenSize = new Size(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height);
            var TaskBarSize = new Size((ScreenSize.Width - (ScreenSize.Width - OutTaskBarSize.Width)), (ScreenSize.Height - OutTaskBarSize.Height));
            MoveWindow(this.Handle, rcMin.Width - rcMin.X, (TaskBarSize.Height - this.Height) / 2, this.Width, this.Height, true);
            RefreshLrc=new Timer(20);
            RefreshLrc.Elapsed += RefreshLrc_Elapsed;
            RefreshLrc.Start();
        }

        private void RefreshLrc_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
           SetTextInvoke text=new SetTextInvoke(LabelLrc,StrLrc);
           text.SetText();
        }
    }

    class SetTextInvoke
    {
        private Label _label;
        private string _str;
        public SetTextInvoke(Label label,string str)
        {
            _label = label;
            _str = str;
        }

        public void SetText()
        {
            _label.Invoke(new Action(() => _label.Text = _str));
        }
    }
}
