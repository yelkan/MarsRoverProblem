using MarsRover.Common.Extensions;
using MarsRover.Model;
using System;
using System.Linq;

namespace MarsRover.Manager
{
    public static class PlateuManager
    {
        public static Plateau Insert(string input)
        {
            var inputList = input.Split(' ');

            Plateau plateau = new Plateau
            {
                X = inputList[0].ConvertInt(),
                Y = inputList[1].ConvertInt(),
                IsSuccess = true
            };

            Console.WriteLine($"Succes a new pleatue: { plateau.X }, { plateau.Y} ");
            return plateau;
        }

        public static bool Validate(string input)
        {
            var inputList = input.Split(' ');

            if (inputList.Count() != 2)
                throw new ArgumentException("Invalid input. Please input validate (5 5).");

            foreach (var coordinate in inputList)
            {
                coordinate.ConvertInt();
            }
            return true;
        }
    }
}
