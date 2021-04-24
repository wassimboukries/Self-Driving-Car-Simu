using System;
using System.Collections.Generic;

namespace SelfDriving_car_Simu
{
    class Vehicule : IEnvironnement
    {
        public static int count = 0;
        public int id { get; set; }
        public int speed = 0;
        public int position { get; set; }
        public Road road;

        public Vehicule()
        {
            count++;
            this.id = count;
            position = 0;
            speedUp();
        }

        public void makeAction(int time)
        {
            checkRoad();
            position += speed;
        }

        //Checks 
        public void checkRoad()
        {
            //
            if (!checkVehicule())
            {
                if (checkPieton() || checkRondPoint() || checkEndRoad() || checkFeu())
                {
                    //
                    if (speed > 0)
                        speedDown();
                }
                else
                {
                    speedUp();
                }
            }
            else
            {
                if (speed > 0)
                    speedDown();
            }
        }

        public bool checkFeu()
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
                    if (f.color == COLOR.ROUGE)
                        {
                            return true;
                        }
                        else if (f.color == COLOR.ORANGE)
                        {
                            return true;
                        }
                    break;
                }
            }
            return false;
        /*
            else
            {
                if (f.color == COLOR.VERT)
                {
                    speedUp();
                }
            }*/
            
        }

        public bool checkEndRoad()
        {
           if (road.length <= this.position + 10)
           {
                //speed -= 1;
                return true;
           }
           return false;
        }

        public bool checkVehicule()
        {
            foreach (Vehicule v in road.VehiculesOnRoad)
            {
                if (v.position - this.position < 10 && v.position - this.position >= 0)
                {
                    if (v.speed < this.speed)
                    {
                        //this.speed--;
                        return true;
                    }
                    /*else if (v.speed > this.speed)
                    {
                        speedUp();
                    }*/
                }
            }
            return false;
        }

        public bool checkPieton()
        {
            foreach (Piéton p in road.PiétonsOnRoad)
            {
                    if (p.position - this.position < 10 && p.position - this.position >= 0)
                    {
                        if (p.isWillingToPass || p.isPassing)
                        {
                            //speed--;
                            return true;
                        }
                        /*else
                        {
                            speedUp();
                        }*/
                    }
                    /*else
                    {
                        speedUp();
                    }*/

            }
            return false;
        }

        public bool checkRondPoint()
        {
            foreach (RondPoint rp in road.RondPointsOnRoad)
            {
                if (rp.position - this.position < 10 && rp.position - this.position >= 0)
                {
                    if (!rp.isEmpty())
                    {
                            //speed--;
                            return true;
                    }
                    /*else
                    {
                        speedUp();
                    }*/
                }
            }
            return false;
        }

        public void speedUp()
        {
            speed = 4;
        }

        public void speedDown()
        {
            speed--;
        }
    }
}
