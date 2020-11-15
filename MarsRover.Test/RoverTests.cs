using System;
using FluentAssertions;
using NUnit.Framework;
using MarsRover;

namespace MarsRover.Test
{
    class RoverTests
    {
        [TestCase("5 5", "1 2 N", "MMMMMMMMMMMM")]
        [TestCase("5 5", "1 2 N", "LMMM")]
        [TestCase("5 5", "1 2 N", "LLMMM")]
        [TestCase("5 5", "1 2 N", "RRMMM")]
        [TestCase("5 5", "1 2 N", "RRRMMM")]
        public void Rover_Should_Throw_Exception_When_Out_Of_Bounds(string upperBound, string position, string movement)
        {
            Plateu plateu = new Plateu(upperBound);
            Rover rover = new Rover(position, plateu);
            Action action = () => rover.CommandRover(movement);
            action.Should().Throw<IndexOutOfRangeException>();
        }

        [TestCase("5 5", "1 2 N", "LAB")]
        public void Rover_Should_Throw_Exception_When_Movement_Value_Is_Incorrect(string upperBound, string position, string movement)
        {
            Plateu plateu = new Plateu(upperBound);
            Rover rover = new Rover(position, plateu);
            Action action = () => rover.CommandRover(movement);
            action.Should().Throw<ArgumentException>();
        }

        [TestCase("5 5", "1 2 A")]
        public void Rover_Should_Throw_Exception_When_Position_Value_Is_Incorrect(string upperBound, string position)
        {
            Plateu plateu = new Plateu(upperBound);
            Action action = () => new Rover(position, plateu);
            action.Should().Throw<ArgumentException>();
        }

        [TestCase("5 5", "1 2 N", "L", "12W")]
        [TestCase("5 5", "1 2 N", "R", "12E")]
        [TestCase("5 5", "1 2 N", "RR", "12S")]
        [TestCase("5 5", "1 2 N", "LL", "12S")]
        public void Rover_Should_Give_The_Correct_Direction_Data_When_Turned(string upperBound, string position, string movement, string result)
        {
            Plateu plateu = new Plateu(upperBound);
            Rover rover = new Rover(position, plateu);
            rover.CommandRover(movement);
            rover.ToString().Should().Be(result);
        }

        [TestCase("5 5", "1 2 N", "MM", "14N")]
        [TestCase("5 5", "1 2 W", "M", "02W")]
        [TestCase("5 5", "1 2 S", "MM", "10S")]
        [TestCase("5 5", "1 2 E", "MM", "32E")]
        public void Rover_Should_Move_Correctly_When_Instructued(string upperBound, string position, string movement, string result)
        {
            Plateu plateu = new Plateu(upperBound);
            Rover rover = new Rover(position, plateu);
            rover.CommandRover(movement);
            rover.ToString().Should().Be(result);
        }
    }
}
