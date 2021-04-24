using System;
using System.Collections.Generic;
using System.Text;

namespace SelfDriving_car_Simu
{
    interface IEnvironnement
    {
        public int position { get; set; }
        public static int count;
        public int id { get; set; }

        public void makeAction(int time);
    }

}