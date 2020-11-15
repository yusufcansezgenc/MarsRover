using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public class Vector
    {
        private double length;
        private double X { get; set; }
        private double Y { get; set; }
        private double vectorRadian;

        public Vector(double vectorRadian, double length)
        {
            this.vectorRadian = vectorRadian;
            this.length = length;
            CalculateCoordinents();
        }

        //Classic parametric equation for vectors
        private void CalculateCoordinents()
        {
            X = length * Math.Round(Math.Cos(vectorRadian));
            Y = length * Math.Round(Math.Sin(vectorRadian));
        }

        public void TurnVector(double turnRadian)
        {
            vectorRadian += turnRadian;
            CalculateCoordinents();
        }

        public double GetX()
        {
            return X;
        }

        public double GetY()
        {
            return Y;
        }

        /*Degrees that are bigger than 360 degrees or lower than 0 degrees should be brought back 
        into between 0 and 360 degrees by taking the modulus of the overflown radian.
        We are doing this because when we want to find our rover's direction (as in NWSE) 
        we use radian values to search in the dictionary. 
        Overflown radian values cannot be found in the dictionary if not normalized accordingly*/
        public double GetNormalizedVectorRadian()
        {
            if((vectorRadian > 2 * Math.PI) || vectorRadian <= 0)
            {
                vectorRadian = vectorRadian % (2 * Math.PI);

                if (vectorRadian <= 0)
                {
                    vectorRadian += 2 * Math.PI;
                }

                if (vectorRadian == 0)
                {
                    vectorRadian = 2 * Math.PI;
                }
            }
            return vectorRadian;
        }
    }
}
