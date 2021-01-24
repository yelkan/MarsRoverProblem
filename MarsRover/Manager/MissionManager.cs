using MarsRover.Model;
using MarsRover.Service;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace MarsRover.Manager
{
    public static class MissionManager
    {
        public static List<RoverInfo> MissionStart(MarsRoverService service, Mission mission)
        {
            Console.BackgroundColor = ConsoleColor.Black;

            foreach (PropertyInfo propertyInfo in mission.GetType().GetProperties())
            {
                switch (propertyInfo.Name)
                {
                    case nameof(mission.Plateau):
                        if (mission.Plateau.IsSuccess)
                            break;
                        Console.Write("Plateau Info :");
                        Plateau plateau = service.AddPlateu(Console.ReadLine());
                        mission.Plateau = plateau;
                        break;
                    case nameof(mission.RoverCount):
                        if (mission.RoverCount.IsSuccess)
                            break;
                        Console.Write("Rover Count:");
                        RoverCount roverCount = service.AddRoverCount(Console.ReadLine());
                        mission.RoverCount = roverCount;
                        var rovers = new List<Rover>();
                        for (int i = 0; i < roverCount.Count; i++)
                        {
                            rovers.Add(new Rover());
                        }
                        mission.Rovers = rovers;
                        break;
                    case nameof(mission.Rovers):
                        for (int i = 0; i < mission.RoverCount.Count; i++)
                        {
                            if (mission.Rovers[i].IsSuccess)
                                break;

                            Console.WriteLine($"{i} - Rover Setup ");
                            RoverInfo roverInfo = service.SetupRoverInfo(Console.ReadLine());
                            RoverMove roverMove = service.SetupRoverMove(Console.ReadLine());
                            mission.Rovers[i] = service.AddRover(roverInfo, roverMove);
                        }
                        Console.WriteLine($" Rover Setup End ");
                        break;
                    default:
                        break;
                }
            }

            var result = new List<RoverInfo>();
            for (int i = 0; i < mission.RoverCount.Count; i++)
            {
                var rover = mission.Rovers[i];
                var serviceResult = service.StartDiscovering(mission.Plateau, rover);
                result.Add(serviceResult);

                Console.WriteLine($"Info Mission > {i} - Rover : {serviceResult.X} {serviceResult.Y} {serviceResult.Direction}, IsSuccess:{serviceResult.IsSuccess} ");

                if (!serviceResult.IsSuccess)
                    Console.WriteLine($" \t Failed Detail: { serviceResult.ErrorMessage }");
            };

            return result;
        }

        public static bool Validate(Mission mission)
        {
            if (mission == null || mission.Plateau == null || mission.RoverCount == null || mission.Rovers.Count < 1 || mission.Rovers == null)
                return false;

            if (mission == new Mission()  ||  mission.Plateau == new Plateau() || mission.RoverCount == new RoverCount() || mission.Rovers == new List<Rover>())
                return false;

            return true;
        }
    }
}
