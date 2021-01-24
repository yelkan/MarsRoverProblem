using MarsRover.Model;
using MarsRover.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRoverTest
{
    [TestClass]
    public class MarsRoverTest
    {
        [TestClass]
        public class MarsrRoverTest
        {
            public MarsRoverService service;

            [TestInitialize]
            public void Initialize()
            {
                service = new MarsRoverService();
            }

            [TestMethod]
            public void AddPlateu_Valid()
            {
                string input = "5 5";
                var result = service.AddPlateu(input);
                Assert.IsTrue(result.IsSuccess);
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentException))]
            public void AddPlateu_InValid()
            {
                string input = "55";
                 service.AddPlateu(input);
            }

            [TestMethod]
            public void AddRoverCount_Valid()
            {
                string input = "2";
                var result = service.AddRoverCount(input);
                Assert.IsTrue(result.IsSuccess);
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentException))]
            public void AddRoverCount_InValid()
            {
                string input = "A";
                service.AddPlateu(input);
            }

            [TestMethod]
            public void SetupRoverInfo_Valid()
            {
                string input = "1 2 N";
                var result = service.SetupRoverInfo(input);
                Assert.IsTrue(result.IsSuccess);
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentException))]
            public void SetupRoverInfo_Invalid()
            {
                string input = "1 2 Q";
                var result = service.SetupRoverInfo(input);
                Assert.IsTrue(result.IsSuccess);
            }

            [TestMethod]
            public void SetupRoverMove_Valid()
            {
                string input = "LMLMLMLMM";
                var result = service.SetupRoverMove(input);
                Assert.IsTrue(result.IsSuccess);
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentException))]
            public void SetupRoverMove_InValid()
            {
                string input = "QLMLMLMLMM";
                var result = service.SetupRoverInfo(input);
                Assert.IsTrue(result.IsSuccess);
            }

            [TestMethod]
            public void AddRover_Valid()
            {
                RoverInfo roverInfo = new RoverInfo()
                {
                    X = 1,
                    Y = 2,
                    Direction = Compass.N,
                    IsSuccess=true
                };

                RoverMove roverMove = new RoverMove()
                {
                    Moves = "LMLMLMLMM",
                    IsSuccess = true
                };

                var result = service.AddRover(roverInfo,roverMove);
                Assert.IsTrue(result.IsSuccess);
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentException))]
            public void AddRover_InValid()
            {
                //invalid test case, because RoverMove is not success

                RoverInfo roverInfo = new RoverInfo()
                {
                    X = 1,
                    Y = 2,
                    Direction = Compass.N,
                    IsSuccess = true
                };

                RoverMove roverMove = new RoverMove()
                {
                    Moves = "LMLMLMLMM",
                    IsSuccess = false
                };

                var result = service.AddRover(roverInfo, roverMove);
                Assert.IsTrue(result.IsSuccess);
            }

            [TestMethod]
            public void StartDiscovering_Valid()
            {
                var plateu = new Plateau()
                {
                    X = 5,
                    Y = 5,
                    IsSuccess = true
                };

                var rover = new Rover()
                {
                    Info = new RoverInfo()
                    {
                        X = 1,
                        Y = 2,
                        Direction = Compass.N,
                        IsSuccess = true
                    },
                    Moves = new RoverMove()
                    {
                        Moves = "LMLMLMLMM",
                        IsSuccess = true
                    },
                    IsSuccess = true
                };

                var result = service.StartDiscovering(plateu, rover);
                Assert.IsTrue(result.IsSuccess);
            }

            [TestMethod]
            public void StartDiscovering_InValid()
            {
                var plateu = new Plateau()
                {
                    X = 5,
                    Y = 5,
                    IsSuccess = true
                };

                var rover = new Rover()
                {
                    Info = new RoverInfo()
                    {
                        X = 1,
                        Y = 2,
                        Direction = Compass.N,
                        IsSuccess = true
                    },
                    Moves = new RoverMove()
                    {
                        Moves = "MMMMMM",
                        IsSuccess = true
                    },
                    IsSuccess = true
                };

                var result = service.StartDiscovering(plateu, rover);
                Assert.IsFalse(result.IsSuccess);
            }

            [TestMethod]
            public void MissionStart_Valid()
            {

                var plateu = new Plateau()
                {
                    X = 5,
                    Y = 5,
                    IsSuccess = true
                };

                var roverCount = new RoverCount()
                {
                    Count = 2,
                    IsSuccess = true
                };

                var roverOne = new Rover()
                {
                    Info = new RoverInfo()
                    {
                        X = 1,
                        Y = 2,
                        Direction = Compass.N,
                        IsSuccess = true
                    },
                    Moves = new RoverMove()
                    {
                        Moves = "LMLMLMLMM",
                        IsSuccess = true
                    },
                    IsSuccess = true
                };

                var roverTwo = new Rover()
                {
                    Info = new RoverInfo()
                    {
                        X = 3,
                        Y = 3,
                        Direction = Compass.E,
                        IsSuccess = true
                    },
                    Moves = new RoverMove()
                    {
                        Moves = "MMRMMRMRRM",
                        IsSuccess = true
                    },
                    IsSuccess = true
                };

                var roverList = new List<Rover>
                {
                    roverOne,
                    roverTwo
                };

                var mission = new Mission
                {
                    Plateau = plateu,
                    RoverCount = roverCount,
                    Rovers = roverList,
                    IsSuccess = true
                };

                var result = service.MissionStart(mission);

                Assert.IsTrue(!result.Any(x=> !x.IsSuccess));
            }

            [TestMethod]
            public void MissionStart_InValid_IsSuccesMission()
            {

                var plateu = new Plateau()
                {
                    X = 5,
                    Y = 5,
                    IsSuccess = true
                };

                var roverCount = new RoverCount()
                {
                    Count = 2,
                    IsSuccess = true
                };

                var roverOne = new Rover()
                {
                    Info = new RoverInfo()
                    {
                        X = 1,
                        Y = 2,
                        Direction = Compass.N,
                        IsSuccess = true
                    },
                    Moves = new RoverMove()
                    {
                        Moves = "LMLMLMLMM",
                        IsSuccess = true
                    },
                    IsSuccess = true
                };

                var roverTwo = new Rover()
                {
                    Info = new RoverInfo()
                    {
                        X =5,
                        Y =5,
                        Direction = Compass.E,
                        IsSuccess = true
                    },
                    Moves = new RoverMove()
                    {
                        Moves = "MMRMMRMRRM",
                        IsSuccess = true
                    },
                    IsSuccess = true
                };

                var roverList = new List<Rover>
                {
                    roverOne,
                    roverTwo
                };

                var mission = new Mission
                {
                    Plateau = plateu,
                    RoverCount = roverCount,
                    Rovers = roverList,
                    IsSuccess = true
                };

                var result = service.MissionStart(mission);

                Assert.IsTrue(result.Any(x => !x.IsSuccess));
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentException))]
            public void MissionStart_InValid()
            {
                var mission = new Mission();

                 service.MissionStart(mission);
            }
        }
    }
}
