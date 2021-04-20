﻿using System;
using System.IO;

namespace SelfDriving_car_Simu
{
    class Program
    {
        /* **************** */
        /* TESLA SIMULATION */
        /* **************** */
        static void Main(string[] args)
        {
            Vehicule car1 = new Vehicule();
            Vehicule car2 = new Vehicule();
            Vehicule car3 = new Vehicule();
            Road road1 = new Road();
            road1.createVehicule(car1, 0);
            road1.createVehicule(car2, 1);
            road1.createVehicule(car3, 2);
            road1.addFeu(200);
            road1.addFeu(284);
            car1.speed = 5;

            //road1.VehiculesOnRoad.Add(car1);
            using (StreamWriter writer = new StreamWriter("../../../Result.txt"))
            {
                writer.WriteLine($"Feu 1: {road1.feux[0].color}");
                writer.WriteLine($"Feu 2: {road1.feux[1].color}");
                writer.WriteLine($"position : {car1.position}  - speed : {car1.speed}");
                writer.WriteLine($"position : {car2.position}  - speed : {car2.speed}");
                writer.WriteLine($"position : {car3.position}  - speed : {car3.speed}");
                int time = 0;
            
                while (time < 200)
                {   
                    road1.changeFeux(time);

                    car3.makeAction();
                    car2.makeAction();
                    car1.makeAction();
                    
                    writer.WriteLine($"Feu 1: {road1.feux[0].color}");
                    writer.WriteLine($"Feu 2: {road1.feux[1].color}");
                    writer.WriteLine($"position : {car1.position}  - speed : {car1.speed}");
                    writer.WriteLine($"position : {car2.position}  - speed : {car2.speed}");
                    writer.WriteLine($"position : {car3.position}  - speed : {car3.speed}");
                    time++;
                }
            }
        }
    }
}
