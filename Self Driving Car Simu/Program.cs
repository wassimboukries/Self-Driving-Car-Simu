using System;
using System.IO;

namespace SelfDriving_car_Simu
{
    class Program
    {
        static void Main(string[] args)
        {
            Road road1 = new Road();

            //Creating new Vehicules and adding them to Road1
            road1.addVehiculeToRoad(2);
            road1.addVehiculeToRoad(1);
            road1.addVehiculeToRoad(0);
            
            road1.VehiculesOnRoad[0].speed = 5;
            
            //Creating new red lights and adding them to Road1
            road1.addFeuToRoad(200);
            road1.addFeuToRoad(284);

            //Creating new Piéton and adding it to Road1 with given position
            road1.addPietonToRoad(30);

            //Creating new Round About and adding it to Road1 with given position
            road1.addRondPointToRoad(107);
            
            //Adding vehicules passing through the round about for a given time (timeEntre)
            road1.RondPointsOnRoad[0].addVehiculeIsPassing(28);
            road1.RondPointsOnRoad[0].addVehiculeIsPassing(29);
            
            
            //Printing result 
            using (StreamWriter writer = new StreamWriter("../../../Result.txt"))
            {
                writer.WriteLine($"Time: {-1}");
                //road1.makeAction(-1, writer);
                for (int time=0;  time < 200; time ++)
                {
                    writer.WriteLine($"Time: {time}");

                    road1.makeAction(time, writer);

                    writer.WriteLine("\n\n");
                }
            }
        }
    }
}
