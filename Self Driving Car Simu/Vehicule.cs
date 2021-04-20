using System;
using System.Collections.Generic;

namespace SelfDriving_car_Simu
{
    class Vehicule
    {
        public static int count = 0;
        public int id = count;
        public double speed = 0;
        public int position = 0;//px
        public List<int> NeighboursLeft = new List<int>();
        public List<int> NeighboursFront = new List<int>();
        public Road road; 

        public Vehicule()
        {
            count++;
            this.id = count;
            speedUp();
        }

        public void makeAction()
        {
            checkRoad();
            position += speed;
        }

        //Checks 
        public void checkRoad()
        {
            foreach (Feu f in road.feux)
            {
                if (f.position - this.position > 10 )
                {
                    break;
                }
                else if(f.position - this.position >= 0)
                {
                    checkFeu(f);
                    break;
                }
            }
        }

        public void checkFeu(Feu f)
        {
            if (f.color == COLOR.ROUGE)
            {
                speed /= 4;
            }
            else if (f.color == COLOR.ORANGE)
            {
                speed /= 2;
            }
        }


        public void speedUp()
        {
            speed = 5;
            //position += speed;
        }

        public void speedDown()
        {
            speed--;
            //position -= speed;
        }

        public void addLeftNeighbour(int id)
        {
            NeighboursLeft.Add(id);
        }

        public void addFrontNeighbour(int id)
        {
            NeighboursFront.Add(id);
        }
    }
}
