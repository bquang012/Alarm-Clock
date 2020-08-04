using System;
using System.Text;
using System.Runtime.InteropServices;

namespace Q_HenGio
{
    class PlayMP3:IDisposable
    {
        [DllImport("winmm.dll")]
        private static extern long mciSendString(String strcommand, StringBuilder strReturn,
            int iReturnLength, IntPtr hwndCallBack);

        private bool repeat = false;

        public bool Repeat
        {
            get
            {
                return repeat;
            }

            set
            {
                repeat = value;
            }
        }

        public PlayMP3(string fileName)
        {
            const string format = @"open ""{0}"" type mpegvideo alias Mediafile";
            string cmd = string.Format(format, fileName);
            mciSendString(cmd, null, 0, IntPtr.Zero);
        }

        public void play()
        {
            string cmd = "play MediaFile";
            if (Repeat) cmd += " REPEAT";
            mciSendString(cmd, null, 0, IntPtr.Zero);
        }
        public void stop()
        {
            string cmd = "stop MediaFile";
            mciSendString(cmd, null, 0, IntPtr.Zero);
        }

        public void Dispose()
        {
            string cmd = "close MediaFile";
            mciSendString(cmd, null, 0, IntPtr.Zero);
        }
    }
}
