using System;
using System.Collections.Generic;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Upper Bound Values: ");
            string upperBoundValues = Console.ReadLine();
            Plateu marsPletau = new Plateu(upperBoundValues);

            Console.WriteLine("Enter Position Values: ");
            string positionValues = Console.ReadLine();
            Rover rover = new Rover(positionValues, marsPletau);

            Console.WriteLine("Enter Movement Values: ");
            string movementValues = Console.ReadLine();
            rover.CommandRover(movementValues);

            Console.WriteLine(rover);
            Console.ReadKey();
        }
    }
}
