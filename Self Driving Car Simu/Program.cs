using System;

namespace SelfDriving_car_Simu
{
    class Program
    {
        static void Main(string[] args)
        {
            Vehicule car1 = new Vehicule();
            Road road1 = new Road();
            road1.createVehicule(car1);
            road1.addFeu(220);

            //road1.VehiculesOnRoad.Add(car1);
            int time = 0;

            while(time < 200)
            {
                car1.makeAction();
                road1.changeFeux(time);
                Console.WriteLine($"position : {car1.position}  - speed : {car1.speed}");
                Console.WriteLine($"{road1.feux[0].color}");
                time++;
            }
        }
    }
}
