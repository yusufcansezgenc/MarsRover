using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public class Plateu
    {
        private (int X, int Y) LowerBound { get; set; } = (X: 0, Y: 0);
        private (int X, int Y) UpperBound { get; set; }

        public Plateu(string upperBoundValues)
        {
            string[] upperBoundValuesArray = upperBoundValues.Split(' ');
            UpperBound = (X: Convert.ToInt32(upperBoundValuesArray[0]), 
                Y: Convert.ToInt32(upperBoundValuesArray[1]));

            if((UpperBound.X < 0 || UpperBound.Y < 0) || 
                (UpperBound.X == 0 && UpperBound.Y == 0))
            {
                throw new ArgumentException("Negative or both zero upper bound values are not allowed.");
            }
        }

        public bool IsRoverInPlateu(double roverX, double roverY)
        {
            var MinX = Math.Min(LowerBound.X, UpperBound.X);
            var MaxX = Math.Max(LowerBound.X, UpperBound.X);
            var MinY = Math.Min(LowerBound.Y, UpperBound.Y);
            var MaxY = Math.Max(LowerBound.Y, UpperBound.Y);
            return (roverX >= MinX && roverX <= MaxX) &&
                   (roverY >= MinY && roverY <= MaxY);
        }
    }
}
