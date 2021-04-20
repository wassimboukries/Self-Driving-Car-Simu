﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SelfDriving_car_Simu
{
    enum COLOR {VERT, ORANGE, ROUGE}

    class Feu
    {
        public int id;
        public int position;
        public COLOR color = COLOR.ROUGE;
        
        public Feu(int position)
        {
            this.position = position;
        }

        public bool change(int time)
        {
            bool hasChanged = false;
            if (time % 40 == 0)
            {
                hasChanged = true;
                if (color == COLOR.VERT)
                {
                    color = COLOR.ORANGE;
                }
                else if (color == COLOR.ORANGE)
                {
                    color = COLOR.ROUGE;
                }
                else if (color == COLOR.ROUGE)
                {
                    color = COLOR.VERT;
                }
            }
            return hasChanged;
        }
    }
}