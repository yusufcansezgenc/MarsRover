using System;
using FluentAssertions;
using NUnit.Framework;
using MarsRover;

namespace MarsRover.Test
{
    class PlateuTests
    {
        [TestCase("-5 -5")]
        [TestCase("0 0")]
        public void Plateu_Should_Throw_Exception_When_Values_Are_Zero_Or_Negative(string upperBound)
        {
            Action action = () => new Plateu(upperBound);
            action.Should().Throw<ArgumentException>();
        }

        [TestCase("5 5", -1, -1, false)]
        [TestCase("5 5", 1, 0, true)]
        [TestCase("5 5", 999, 999, false)]
        [TestCase("5 5", 0, 0, true)]
        public void Plateu_Should_Correctly_Determine_If_Rover_Is_In_It_Or_Not(string upperBound, int roverX, int roverY, bool expectedValue)
        {
            Plateu plateu = new Plateu(upperBound);
            plateu.IsRoverInPlateu(roverX, roverY).Should().Be(expectedValue);
        }
    }
}
