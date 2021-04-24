using System;
using System.Collections.Generic;
using System.Text;

namespace SelfDriving_car_Simu
{
    class Road
    {
        public static int count = 0;
        public int id = count;
        
        public int length = 300; //px
        public List<Feu> feux = new List<Feu>();
        public List<Vehicule> VehiculesOnRoad = new List<Vehicule>();
        public List<Piéton> PiétonsOnRoad = new List<Piéton>();
        public List<RondPoint> RondPointsOnRoad = new List<RondPoint>();

        public Road()
        {
            count++;
            id = count;
        }

        public void addFeu(int position)
        {
            feux.Add(new Feu(position));
        }

        public void addVehiculeToRoad(Vehicule vehicule, int position)
        {
            vehicule.road = this;
            vehicule.position = position;
            VehiculesOnRoad.Add(vehicule);
        }

        public void addPietonToRoad(Piéton pieton)
        {
            PiétonsOnRoad.Add(pieton);
        }

        public void addRondPoint(RondPoint rondPoint)
        {
            RondPointsOnRoad.Add(rondPoint);
        }

        public void changeFeux(int time)
        {
            foreach(Feu f in feux)
            {
                f.change(time + f.id +12);
            } 
        }
    }
}
