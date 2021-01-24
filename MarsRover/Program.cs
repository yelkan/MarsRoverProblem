using MarsRover.Model;
using MarsRover.Service;
using System;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" >>>> Welcome <<<< ");

            Mission mission = new Mission().GetMission();

            try
            {
                ProcessStart(mission);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, Console.BackgroundColor = ConsoleColor.DarkYellow);
                ProcessStart(mission);
            }
        }

        static void ProcessStart(Mission mission)
        {
            try
            {
                MarsRoverService service = new MarsRoverService();
                service.MissionStart(mission);
                Console.WriteLine(" >>>> Process End <<<< ");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, Console.BackgroundColor = ConsoleColor.DarkRed);
                ProcessStart(mission);
            }
        }
    }
}
