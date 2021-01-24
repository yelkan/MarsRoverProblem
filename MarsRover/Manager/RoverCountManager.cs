using MarsRover.Common.Extensions;
using MarsRover.Model;
using System;
using System.Collections.Generic;

namespace MarsRover.Manager
{
    public static class RoverCountManager
    {
        public static RoverCount Insert(string input)
        {
            var roverCount = new RoverCount
            {
                Count = input.ConvertInt(),
                IsSuccess = true
            };

            return roverCount;
        }
        public static bool Validate(string input)
        {
            if (!input.IsInt())
                throw new ArgumentException("Error occurred while creating Rover Count, try again.");

            return true;
        }
    }
}
