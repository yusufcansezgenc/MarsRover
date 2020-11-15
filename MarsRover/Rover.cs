using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRover
{
    public class Rover
    {
        private readonly Dictionary<char, double> directionDegrees =
            new Dictionary<char, double>()
            {
                {'N', Math.PI / 2}, //90 degrees
                {'W', Math.PI}, //180 degrees
                {'S', (3 * Math.PI) / 2}, //270 degrees
                {'E', (2 * Math.PI)} //360 degrees
            };

        private readonly Dictionary<char, double> turnValueDegrees =
            new Dictionary<char, double>()
            {
                {'L', Math.PI / 2},
                {'R', -Math.PI / 2},
            };

        private Vector directionVector;
        private Plateu marsPlateu;

        private double currentX;
        private double currentY;
        private readonly double movementLength = 1;

        public Rover(string positionValues, Plateu marsPlateu)
        {
            string[] positionValuesArray = positionValues.Split(' ');

            currentX = Convert.ToInt32(positionValuesArray[0]);
            currentY = Convert.ToInt32(positionValuesArray[1]);

            bool isValid = directionDegrees.
                TryGetValue(Convert.ToChar(positionValuesArray[2]), 
                out double radian);

            if (isValid)
            {
                directionVector = new Vector(radian, movementLength);
            }
            else
            {
                throw new ArgumentException(string.Format("Invalid Input {0}", 
                    positionValuesArray[2]));
            }

            this.marsPlateu = marsPlateu;
        }

        public void CommandRover(string movementValues)
        {
            foreach (var movementValue in movementValues)
            {
                if (movementValue == 'M')
                {
                    MoveRover();
                }
                else
                {
                    TurnRover(movementValue);
                }
            }
        }

        public override string ToString()
        {
            return String.Format("{0}{1}{2}", GetCurrentX(), GetCurrentY(), GetDirection());
        }

        private void TurnRover(char side)
        {
            bool isValid = turnValueDegrees.TryGetValue(side, out double radian);
            if (isValid)
            {
                directionVector.TurnVector(radian);
            }
            else
            {
                throw new ArgumentException(string.Format("Invalid Input {0}", side));
            }
        }

        private void MoveRover()
        {
            currentX += directionVector.GetX();
            currentY += directionVector.GetY();

            if(!marsPlateu.IsRoverInPlateu(currentX, currentY))
            {
                throw new IndexOutOfRangeException(string.Format("Rover got out of range!"));
            }
        }

        private double GetCurrentX()
        {
            return currentX;
        }

        private double GetCurrentY()
        {
            return currentY;
        }

        private char GetDirection()
        {
            return directionDegrees.
                FirstOrDefault(x => x.Value == directionVector.
                GetNormalizedVectorRadian()).Key;
        }

    }
}
