using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;


namespace Q_HenGio
{
    public partial class frmClocker : Form
    {
        public frmClocker()
        {
            InitializeComponent();

            lbDay.Text = DateTime.Now.DayOfWeek.ToString();
            time.Interval = 60000- DateTime.Now.Second*1000;
            time.Tick += new EventHandler(this.Time_Tick);
            time.Start();
            partSound = "Sound/nhacChuong.mp3";
        }

        private int khoiTaoNgay(DateTime d)
        {
            int today = -1;
            switch (d.DayOfWeek)
            {
                case DayOfWeek.Sunday: today = 0; break;
                case DayOfWeek.Monday: today = 1; break;
                case DayOfWeek.Tuesday: today = 2; break;
                case DayOfWeek.Wednesday: today = 3; break;
                case DayOfWeek.Thursday: today = 4; break;
                case DayOfWeek.Friday: today = 5; break;
                case DayOfWeek.Saturday: today = 6; break;
            }
            lbDay.Text = d.DayOfWeek.ToString();
            return today;
        }
        private string partSound = "";
        private void Time_Tick(object sender, EventArgs e)
        {
            DateTime d = DateTime.Now;
            int today = khoiTaoNgay(d);
            time.Interval = 60000;
            for (int i=0; i<arrClocker.Count; i++)
            {
                if(arrClocker[i].active)
                {
                    if(arrClocker[i].dayOfWeek[today])
                    {
                        if(arrClocker[i].gio == d.Hour && arrClocker[i].phut==d.Minute)
                        {
                            BaoThuc dgBaoThuc = new BaoThuc(arrClocker[i].gio, arrClocker[i].phut, partSound);
                            dgBaoThuc.ShowDialog(this);
                            showForm();

                        }
                    }
                }
            }
        }

        List<Clock> arrClocker = new List<Clock>();

        Timer time = new Timer();


        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddTime f = new frmAddTime();
            f.ShowDialog();
            if (f.ok == true)
            {
                int index = arrClocker.Count;

                List<Clock> gan = new List<Clock>();
                gan.AddRange(arrClocker);

                //sắp xếp
                gan.Sort(
                    (p1, p2) =>
                    {
                        if (p1.id > p2.id)
                            return 1;
                        else if (p1.id == p2.id)
                            return 0;
                        return -1;
                    }
                    );

                //Tìm id phù hợp
                for(int i=0; i<gan.Count; i++)
                {
                    if(!gan[i].Name.Equals("Clock"+i))
                    {
                        index = i;
                        break;
                    }
                }
                
                Clock new_clock = new Clock(f.gio, f.phut, f.dayOfWeek, index);
                arrClocker.Add(new_clock);
                pnTime.Controls.Add(new_clock);

                //set event
                new_clock.DoubleClick += new EventHandler(this.Clock_DoubleClick);
                new_clock.btnXoa.Click += new EventHandler(this.btnXoa_Click);
            }
        }
        
        private void btnXoa_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;

            //Xóa trong panel
            pnTime.Controls.Remove(Controls.Find(p.Parent.Name, true).First());

            //Xóa trong database
            for(int i=0; i<arrClocker.Count; i++)
            {
                if(arrClocker[i].Name.Equals(p.Parent.Name))
                {
                    arrClocker.RemoveAt(i);
                    break;
                }
            }
        }

        private void Clock_DoubleClick(object sender, EventArgs e)
        {
            Clock c = (Clock)sender;
            
            frmAddTime f = new frmAddTime(c.gio, c.phut, c.dayOfWeek);
            f.ShowDialog();
            if (f.ok)
            {
                c.gio = f.gio;
                c.phut = f.phut;
                c.dayOfWeek = f.dayOfWeek;
            }
        }

        private void clock1_Load(object sender, EventArgs e)
        {

        }

        private void btnChangeSound_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "Mp3 File (*.mp3)|*.mp3|Wav File (*.wav)|*.wav;";
            if (f.ShowDialog() != DialogResult.OK) return;

            if (f.FileName.EndsWith(".wav"))
            {
                partSound = f.FileName;
            }
            else if(f.FileName.EndsWith(".mp3"))
            {
                
            }
            else
            {
                MessageBox.Show("Không phải file này.");
            }
        }
        
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //Save file trước khi thoát
                List<Time_List> t = new List<Time_List>();

                for (int i = 0; i < arrClocker.Count; i++)
                {
                    t.Add(new Time_List(arrClocker[i].gio, arrClocker[i].phut, arrClocker[i].dayOfWeek
                        , arrClocker[i].active, arrClocker[i].id));
                }

                XmlSerializer xmlSer = new XmlSerializer(typeof(List<Time_List>));

                FileStream fs = new FileStream(Environment.CurrentDirectory + "\\save.xml", FileMode.Create, FileAccess.Write);

                xmlSer.Serialize(fs, t);
                fs.Close();
            }
            catch(Exception ae)
            {
                MessageBox.Show(ae.Message);
            }
            Application.Exit();

        }

        private void showForm()
        {
            ShowInTaskbar = true;
            ShowIcon = true;
            notifyIcon1.Visible = false;
            this.Show();
            WindowState = FormWindowState.Normal;
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            showForm();
        }

        private void itemShow_Click(object sender, EventArgs e)
        {
            showForm();
        }

        private void frmClocker_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShowIcon = false;
            ShowInTaskbar = false;
            this.Hide();
            notifyIcon1.Visible = true;
            notifyIcon1.ShowBalloonTip(1000);
            e.Cancel = true;
        }

        private void frmClocker_Load(object sender, EventArgs e)
        {
            if(File.Exists(Environment.CurrentDirectory+"\\save.xml"))
            {
                List<Time_List> t = new List<Time_List>();

                XmlSerializer xmlSer = new XmlSerializer(typeof(List<Time_List>));

                FileStream fs = new FileStream(Environment.CurrentDirectory + "\\save.xml", FileMode.Open, FileAccess.Read);

                t = xmlSer.Deserialize(fs) as List<Time_List>;

                for (int i = 0; i < t.Count; i++)
                {
                    Clock item = new Clock(t[i].gio, t[i].phut, t[i].dayOfWeek, t[i].Id);
                    item.active = t[i].Active;

                    arrClocker.Add(item);
                    pnTime.Controls.Add(item);

                    //set event
                    item.DoubleClick += new EventHandler(this.Clock_DoubleClick);
                    item.btnXoa.Click += new EventHandler(this.btnXoa_Click);
                }
                fs.Close();
            }
        }
    }
}
