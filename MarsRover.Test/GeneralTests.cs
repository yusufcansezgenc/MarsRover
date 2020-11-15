using System;
using FluentAssertions;
using NUnit.Framework;
using MarsRover;

namespace MarsRover.Test
{
    [TestFixture]
    public class GeneralTests
    {
        [TestCase("5 5", "1 2 N", "LMLMLMLMM", "13N")]
        [TestCase("5 5", "3 3 E", "MMRMMRMRRM", "51E")]
        public void Given_Test_Cases_Should_Pass(string upperBound, string position, string movement, string result)
        {
            Plateu plateu = new Plateu(upperBound);
            Rover rover = new Rover(position, plateu);
            rover.CommandRover(movement);
            rover.ToString().Should().Be(result);
        }
        
    }
}
