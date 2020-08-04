using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q_HenGio
{
    public class Time_List
    {
        private int gio_, phut_;
        private bool[] dayOfWeek_ = new bool[7];
        private bool active_ = true;
        private int id_;

        public int gio
        {
            get
            {
                return gio_;
            }

            set
            {
                gio_ = value;
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

        public bool Active
        {
            get
            {
                return active_;
            }

            set
            {
                active_ = value;
            }
        }

        public int Id
        {
            get
            {
                return id_;
            }

            set
            {
                id_ = value;
            }
        }

        public Time_List() { }

        public Time_List(int g, int p, bool[] d, bool av, int id)
        {
            gio = g;
            phut = p;
            for (int i = 0; i < 7; i++)
                dayOfWeek[i] = d[i];
            Active = av;
            Id = id;
        }
    }
}
