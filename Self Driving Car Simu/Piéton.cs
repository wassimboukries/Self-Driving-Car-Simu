using System;
using System.Collections.Generic;
using System.Text;

namespace SelfDriving_car_Simu
{
    class Piéton
    {
        public int position;
        public int passageTime;
        public bool isPassing = false;
        public bool isWillingToPass = false;
        const int passageDuration = 3;
        public int currentPassageDuration = 0;
        //public Road road;

        public Piéton(int position, int passageTime)
        {
            this.position = position;
            this.passageTime = passageTime;
        }

        public void crossRoad(int time)
        {
            if (time == passageTime)
            {
                isPassing = true;
                currentPassageDuration++;
                isWillingToPass = false;
            }
            else if (time > passageTime)
            {
                if (currentPassageDuration < passageDuration)
                {
                    currentPassageDuration++;
                }
                else if (currentPassageDuration == passageDuration)
                {
                    isPassing = false;
                }
            }
            else if (time + 4 == passageTime)
            {
                isWillingToPass = true;
            }

        }

        
    }
}
