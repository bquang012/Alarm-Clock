using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q_HenGio
{
    public partial class frmAddTime : Form
    {
        public frmAddTime()
        {
            InitializeComponent();

            DateTime d = DateTime.Now;
            gio = d.Hour;
            phut = d.Minute;
            for(int i=0; i<7; i++)
            {
                dayOfWeek[i] = true;
            }
        }
        public frmAddTime(int g, int p, bool[] day)
        {
            InitializeComponent();

            gio = g;
            phut = p;
            
            for (int i = 0; i < 7; i++)
            {
                dayOfWeek[i] = day[i];
                if (!day[0]) btnChuNhat.Checked = false;
                if (!day[1]) btnThu2.Checked = false;
                if (!day[2]) btnThu3.Checked = false;
                if (!day[3]) btnThu4.Checked = false;
                if (!day[4]) btnThu5.Checked = false;
                if (!day[5]) btnThu6.Checked = false;
                if (!day[6]) btnThu7.Checked = false;
                if (!day[i]) btnAllDays.Checked = false;
            }
        }

        private int x, y;

        private int gio_ = 0;
        private int phut_ = 0;
        private bool allDay_ = true;
        private bool[] dayOfWeek_ = new bool[7];
        private bool ok_ = false;

        public int gio
        {
            get
            {
                return gio_;
            }

            set
            {
                gio_ = value;
                if (value < 10)
                    txtGio.Text = "0" + value;
                else
                    txtGio.Text = value + "";

            }
        }

        public int phut
        {
            get
            {
                return phut_;
            }

            set
            {
                phut_ = value;
                if (value < 10)
                    txtPhut.Text = "0" + value;
                else
                    txtPhut.Text = value + "";
            }
        }

        public bool allDay
        {
            get
            {
                return allDay_;
            }

            set
            {
                allDay_ = value;
            }
        }

        public bool[] dayOfWeek
        {
            get
            {
                return dayOfWeek_;
            }

            set
            {
                dayOfWeek_ = value;
            }
        }

        public bool ok
        {
            get
            {
                return ok_;
            }

            set
            {
                ok_ = value;
            }
        }

        private void txtGio_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            //8 = Backspace, 13 = enter
            if(!char.IsDigit(c) && c!=8)
            {
                e.Handled = true;
            }
            if(c==13)
            {
                EventArgs a = new EventArgs();
                btnOK_Click(sender, a);
            }
        }

        private void txtPhut_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (!char.IsDigit(c) && c != 8)
            {
                e.Handled = true;
            }
            if (c == 13)
            {
                EventArgs a = new EventArgs();
                btnOK_Click(sender, a);
            }
        }

        private void txtGio_TextChanged(object sender, EventArgs e)
        {
            int x = 0;
            if (!txtGio.Text.Equals(""))
                x= Int32.Parse(txtGio.Text);
            if (x >= 24) txtGio.Text = 23 + "";
        }

        private void txtPhut_TextChanged(object sender, EventArgs e)
        {
            int x = 0;
            if (!txtPhut.Text.Equals(""))
                x = Int32.Parse(txtPhut.Text);
            if (x >= 60) txtPhut.Text = 59 + "";
        }

        private void btnThu2_CheckedChanged(object sender, EventArgs e)
        {
            btnAllDays.Checked = false;
            if (!dayOfWeek[1])
                dayOfWeek[1] = true;
            else
                dayOfWeek[1] = false;

            btnOK.Focus();
        }

        private void btnThu3_CheckedChanged(object sender, EventArgs e)
        {
            btnAllDays.Checked = false;
            if (!dayOfWeek[2])
                dayOfWeek[2] = true;
            else
                dayOfWeek[2] = false;

            btnOK.Focus();
        }

        private void btnThu4_CheckedChanged(object sender, EventArgs e)
        {
            btnAllDays.Checked = false;
            if (!dayOfWeek[3])
                dayOfWeek[3] = true;
            else
                dayOfWeek[3] = false;

            btnOK.Focus();
        }

        private void btnThu5_CheckedChanged(object sender, EventArgs e)
        {
            btnAllDays.Checked = false;
            if (!dayOfWeek[4])
                dayOfWeek[4] = true;
            else
                dayOfWeek[4] = false;

            btnOK.Focus();
        }

        private void btnThu6_CheckedChanged(object sender, EventArgs e)
        {
            btnAllDays.Checked = false;
            if (!dayOfWeek[5])
                dayOfWeek[5] = true;
            else
                dayOfWeek[5] = false;

            btnOK.Focus();
        }

        private void btnThu7_CheckedChanged(object sender, EventArgs e)
        {
            btnAllDays.Checked = false;
            if (!dayOfWeek[6])
                dayOfWeek[6] = true;
            else
                dayOfWeek[6] = false;

            btnOK.Focus();
        }

        private void btnChuNhat_CheckedChanged(object sender, EventArgs e)
        {
            btnAllDays.Checked = false;
            if (!dayOfWeek[0])
                dayOfWeek[0] = true;
            else
                dayOfWeek[0] = false;

            btnOK.Focus();
        }

        private void btnAllDays_CheckedChanged(object sender, EventArgs e)
        {
            if (btnAllDays.Checked)
            {
                for (int i = 0; i < 7; i++)
                    dayOfWeek[i] = true;
                btnThu2.Checked = true;
                btnThu3.Checked = true;
                btnThu4.Checked = true;
                btnThu5.Checked = true;
                btnThu6.Checked = true;
                btnThu7.Checked = true;
                btnChuNhat.Checked = true;
                btnAllDays.Checked = true;
            }
            btnOK.Focus();
        }

        private void btnChuNhat_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                EventArgs a = new EventArgs();
                btnOK_Click(sender, a);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                gio = Int32.Parse(txtGio.Text);
                phut = Int32.Parse(txtPhut.Text);
            }
            catch (FormatException ae)
            {
                MessageBox.Show(ae+"");
            }
            ok = true;
            this.Close();
        }
        
    }
}
