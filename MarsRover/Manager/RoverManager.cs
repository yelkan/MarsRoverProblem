using MarsRover.Common.Extensions;
using MarsRover.Model;
using System;
using System.Linq;

namespace MarsRover.Manager
{
    public static class RoverManager
    {
        public static Rover Insert(RoverInfo info, RoverMove move)
        {
            var rover = new Rover
            {
                Info = info,
                Moves = move,
                IsSuccess = true
            };

            return rover;
        }

        public static RoverInfo SetupInfo(string input)
        {
            RoverInfo roverInfo = new RoverInfo();
            var inputList = input.Split(' ');

            roverInfo.X = inputList[0].ConvertInt();
            roverInfo.Y = inputList[1].ConvertInt();
            roverInfo.Direction = inputList[2].GetEnum<Compass>();

            roverInfo.IsSuccess = true;
            return roverInfo;
        }

        public static bool Validate(RoverInfo info, RoverMove move)
        {
            if (info == null || move == null || !info.IsSuccess || !move.IsSuccess)
                return false;

            return true;
        }

        public static RoverMove SetupMove(string input)
        {
            var move = new RoverMove
            {
                Moves = input,
                IsSuccess = true
            };
            return move;
        }

        public static bool InfoValidate(string input)
        {
            var inputList = input.Split(' ');

            if (inputList.Count() != 3)
                throw new ArgumentException("Invalid input. Please input validate (1 1 N).");

            foreach (var coordinate in inputList.Take(2))
            {
                coordinate.ConvertInt();
            }

            var isCompass = inputList[2].IsEnum<Compass>();

            if (!isCompass)
                throw new ArgumentException("Invalid input. Compass value hasn't validate. Please input validate (N/E/S/W)");

            return true;
        }

        public static bool MoveValidate(string input)
        {
            var inputList = input.ToCharArray();

            if (inputList.Count() < 1)
                throw new ArgumentException("Invalid input. Please command validate (L/M/N)s.");

            char[] validateCommand = { 'M', 'L', 'R' };


            foreach (var command in inputList)
            {
                if (!validateCommand.Contains(command))
                    throw new ArgumentException("Invalid input. Please command validate (L/M/N)s.");
            }

            return true;
        }

        public static RoverInfo StartDiscovering(Plateau plateau, Rover rover)
        {
            var info = rover.Info;
            foreach (var move in rover.Moves.Moves)
            {
                switch (move)
                {
                    case 'M':
                        rover.Move();
                        break;
                    case 'L':
                        rover.TurnLeft();
                        break;
                    case 'R':
                        rover.TurnRight();
                        break;
                    default:
                        break;
                }

                //Console.WriteLine($"New Coordinate :{info.X},{info.Y},{info.Direction}");
            }

            if (info.X < 0 || info.X > plateau.X || info.Y < 0 || info.Y > plateau.Y)
            {
                info.IsSuccess = false;
                info.ErrorMessage = $"Mission failed! the  Rover went off the plateau.Plateau Bounderis:{ plateau.X},{ plateau.Y}. Rover coordinates :({ info.X},{ info.Y})";
            }

            return info;
        }

    }
}
