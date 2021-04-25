using System;
using System.Collections.Generic;
using System.Text;

namespace SelfDriving_car_Simu
{
    class Piéton : IEnvironnement
    {
        public static int count;
        public int id { get; set; }
        public int position { get; set; }
        public int passageTime;
        public bool isPassing = false;
        public bool isWillingToPass = false;
        const int passageDuration = 3;
        public int currentPassageDuration = 0;

        public Piéton(int position, int passageTime)
        {
            count++;
            id = count;
            this.position = position;
            this.passageTime = passageTime;
        }

        public void makeAction(int time)
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
