using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SelfDriving_car_Simu
{
    class Road
    {
        public static int count = 0;
        public int id { get; set; }
        public int length = 300; //px
        public List<Feu> FeuxOnRoad = new List<Feu>();
        public List<Vehicule> VehiculesOnRoad = new List<Vehicule>();
        public List<Piéton> PiétonsOnRoad = new List<Piéton>();
        public List<RondPoint> RondPointsOnRoad = new List<RondPoint>();

        public Road()
        {
            count++;
            id = count;
        }

        public void addFeuToRoad(int position)
        {
            FeuxOnRoad.Add(new Feu(position));
        }

        public void addVehiculeToRoad(int position)
        {
            Vehicule newV= new Vehicule();
            newV.road = this;
            newV.position = position;
            VehiculesOnRoad.Add(newV);
            VehiculesOnRoad = VehiculesOnRoad.OrderByDescending(v => v.position).ToList();
        }

        public void addPietonToRoad(int position)
        {
            Piéton newPieton = new Piéton(position, 8);
            PiétonsOnRoad.Add(newPieton);
        }

        public void addRondPointToRoad(int position)
        {
            RondPoint rondPoint = new RondPoint(position);
            RondPointsOnRoad.Add(rondPoint);
        }

        public void makeAction(int time, StreamWriter writer)
        {
            foreach(Feu f in FeuxOnRoad)
            {
                f.makeAction(time + f.id +12);
                writer.WriteLine($"Feu n°: {f.id} - position: {f.position} - Color: {f.color}");
            }

            foreach (Piéton p in PiétonsOnRoad)
            {
                p.makeAction(time);
                if (p.isPassing)
                    writer.WriteLine($"################ Piéton {p.id} in position {p.position} is Passing ################");
            }

            foreach (Vehicule v in VehiculesOnRoad)
            {
                v.makeAction(time);
                writer.WriteLine($"Car n°: {v.id} - position: {v.position} - speed : {v.speed}");
            }

            foreach (RondPoint rp in RondPointsOnRoad)
            {
                rp.makeAction(time);
                foreach (bool passing in rp.isPassing)
                {
                    if (passing)
                        writer.WriteLine($"################ Rond Point {rp.id} in position {rp.position} is not empty ################");
                }
            }

        }
    }
}
