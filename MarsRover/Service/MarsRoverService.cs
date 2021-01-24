using MarsRover.Manager;
using MarsRover.Model;
using System;
using System.Collections.Generic;

namespace MarsRover.Service
{
    public class MarsRoverService
    {
        public List<RoverInfo> MissionStart(Mission mission)
        {
            if (!MissionManager.Validate(mission))
                throw new ArgumentException("Error occurred while creating Mission, try again.");

            return MissionManager.MissionStart(this, mission);
        }

        public Plateau AddPlateu(string input)
        {
            if (!PlateuManager.Validate(input))
                throw new ArgumentException("Error occurred while creating Plateu, try again.");

            var result = PlateuManager.Insert(input);
            return result;
        }

        public RoverCount AddRoverCount(string input)
        {
            if (!RoverCountManager.Validate(input))
                throw new ArgumentException("Error occurred while creating Plateu, try again.");

            var result = RoverCountManager.Insert(input);
            return result;
        }

        public Rover AddRover(RoverInfo info, RoverMove move)
        {
            if (!RoverManager.Validate(info, move))
                throw new ArgumentException("Error occurred while creating Rover, try again.");

            var result = RoverManager.Insert(info, move);
            return result;
        }

        public RoverInfo SetupRoverInfo(string input)
        {
            if (!RoverManager.InfoValidate(input))
                throw new ArgumentException("Error occurred while creating Plateu, try again.");

            var result = RoverManager.SetupInfo(input);
            return result;
        }

        public RoverMove SetupRoverMove(string input)
        {
            if (!RoverManager.MoveValidate(input))
                throw new ArgumentException("Error occurred while creating Plateu, try again.");

            var result = RoverManager.SetupMove(input);
            return result;
        }

        public RoverInfo StartDiscovering(Plateau plateau, Rover rover)
        {
            var result = RoverManager.StartDiscovering(plateau, rover);
            return result;
        }
    }
}
