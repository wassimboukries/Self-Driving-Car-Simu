using System;
using System.Collections.Generic;
using System.Text;

namespace SelfDriving_car_Simu
{
    class RondPoint: IEnvironnement
    {
        public static int count;
        public int id { get; set; }
        public List<bool> isPassing = new List<bool>();
        public List<int> currentPassageDurations = new List<int>();
        public List<int> timeEntreeVehiculesOnRondPoint = new List<int>();
        public int position { get; set; }
        public int passageDuration = 4;

        public RondPoint()
        {
            count++;
            id = count;
        }

        public RondPoint(int position)
        {
            this.position = position;
            count++;
            id = count;
        }

        public void addVehiculeIsPassing(int timeEntree)
        {
            timeEntreeVehiculesOnRondPoint.Add(timeEntree);
            currentPassageDurations.Add(0);
            isPassing.Add(false);
        }

        public void makeAction(int time)
        {
            for(int t=0; t<timeEntreeVehiculesOnRondPoint.Count; ++t)
            {
                if (timeEntreeVehiculesOnRondPoint[t] == time)
                {
                    isPassing[t] = true;
                    currentPassageDurations[t]++;
                }
                else if (time > timeEntreeVehiculesOnRondPoint[t])
                {
                    if (currentPassageDurations[t] < passageDuration)
                    {
                        currentPassageDurations[t]++;
                    }
                    else if(currentPassageDurations[t] == passageDuration)
                    {
                        isPassing[t] = false;
                    }
                }
            }
        }

        public bool isEmpty()
        {
            foreach(bool b in isPassing)
            {
                if (b)
                    return false;
            }
            return true;
        }

    }
}
