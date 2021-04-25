using System;
using System.Collections.Generic;
using System.Text;

namespace SelfDriving_car_Simu
{
    enum COLOR {VERT, ORANGE, ROUGE}

    class Feu : IEnvironnement
    {
        public static int count = 0;
        public int id { get; set; }
        public int position { get; set; }
        public COLOR color = COLOR.ROUGE;
        
        public Feu(int position)
        {
            count++;
            this.id = count;
            this.position = position;
        }

        public void makeAction(int time)
        {
            if (time % 20 == 0 && time != 0)
            {
                if (color == COLOR.VERT)
                {
                    color = COLOR.ORANGE;
                }
                else if (color == COLOR.ORANGE)
                {
                    color = COLOR.ROUGE;
                }
                else
                {
                    color = COLOR.VERT;
                }
            }
        }
    }
}
