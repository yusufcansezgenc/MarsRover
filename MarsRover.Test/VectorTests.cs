using System;
using FluentAssertions;
using NUnit.Framework;
using MarsRover;

namespace MarsRover.Test
{
    class VectorTests
    {
        [TestCase((Math.PI / 2), 1, 0, 1)]
        [TestCase((Math.PI), 1, -1, 0)]
        [TestCase(((3 * Math.PI) / 2), 1, 0, -1)]
        [TestCase((2 * Math.PI), 1, 1, 0)]
        [TestCase(0, 1, 1, 0)]
        public void Vector_Should_Give_The_Correct_X_Y_Values(double vectorRadian, 
            double length, double expectedX, double expectedY)
        {
            Vector vector = new Vector(vectorRadian, length);
            vector.GetX().Should().Be(expectedX);
            vector.GetY().Should().Be(expectedY);
        }

        [TestCase((2 * Math.PI) + (Math.PI / 2), 1, 0, 1)]
        [TestCase(-(2 * Math.PI) + (Math.PI / 2), 1, 0, 1)]
        public void Overflown_Radians_Should_Be_Normalized_Accordingly(double vectorRadian, 
            double length, double expectedX, double expectedY)
        {
            Vector vector = new Vector(vectorRadian, length);
            vector.GetX().Should().Be(expectedX);
            vector.GetY().Should().Be(expectedY);
        }

        [TestCase(0, (Math.PI / 2), 1, 0, 1)]
        [TestCase(0, 2 * (Math.PI / 2), 1, -1, 0)]
        [TestCase((Math.PI / 2), -(Math.PI / 2), 1, 1, 0)]
        [TestCase((Math.PI / 2), (Math.PI / 2), 1, -1, 0)]
        public void Vector_Shoud_Give_The_Correct_X_Y_Values_When_Turned(double vectorRadian, 
            double turnRadian, double length, double expectedX, double expectedY)
        {
            Vector vector = new Vector(vectorRadian, length);
            vector.TurnVector(turnRadian);
            vector.GetX().Should().Be(expectedX);
            vector.GetY().Should().Be(expectedY);
        }
    }
}
