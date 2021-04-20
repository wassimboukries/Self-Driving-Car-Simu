using System;
using System.Collections.Generic;

namespace SelfDriving_car_Simu
{
    class Vehicule
    {
        public static int count = 0;
        public int id = count;
        public double speed = 0;
        public double position = 0;//px
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
            if (!checkVehicule())
            {
                foreach (Feu f in road.feux)
                {
                    if (f.position - this.position > 10)
                    {
                        //speedUp();
                        break;
                    }
                    else if (f.position - this.position >= 0)
                    {
                        checkFeu(f);
                        break;
                    }
                }

                checkEndRoad();
            }

        }

        public void checkFeu(Feu f)
        {   
            if (speed > 0)
            {
                if (f.color == COLOR.ROUGE)
                {
                    speed -= 1;
                }
                else if (f.color == COLOR.ORANGE)
                {
                    speed -= 1;
                }
                else
                {
                    speedUp();
                }
            }
            else
            {
                if (f.color == COLOR.VERT)
                {
                    speedUp();
                }
            }
        }

        public void checkEndRoad()
        {
            if (speed > 0)
            {
                if (road.length <= this.position + 10)
                {
                    speed -= 1;
                }
            }
        }

        public bool checkVehicule()
        {
            foreach (Vehicule v in road.VehiculesOnRoad)
            {
                if (v.position - this.position < 10 && v.position - this.position >= 0)
                {
                    if (v.speed < this.speed)
                    {
                        this.speed -= 1;
                        return true;
                    }
                    else if (v.speed > this.speed)
                    {
                        speedUp();
                    }
                }
            }
            return false;
        }

        public void speedUp()
        {
            speed = 4;
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
