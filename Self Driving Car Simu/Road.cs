using System;
using System.Collections.Generic;
using System.Text;

namespace SelfDriving_car_Simu
{
    class Road
    {
        public static int count = 0;
        public int id = count;
        public List<int> VehiculesOnRoad = new List<int>();
        public int length = 300; //px
        public List<Feu> feux = new List<Feu>();

        public Road()
        {
            count++;
            id = count;
        }

        public void addFeu(int position)
        {
            feux.Add(new Feu(position));
        }

        public void createVehicule(Vehicule vehicule, int position)
        {
            vehicule.road = this;
            vehicule.position = position;
        }

        public void changeFeux(int time)
        {
            foreach(Feu f in feux)
            {
                f.change(time);
            } 
        }
    }
}
