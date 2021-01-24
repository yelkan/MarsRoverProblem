using System.Collections.Generic;

namespace MarsRover.Model
{
    public class Mission : BaseModel
    {
        public Plateau Plateau { get; set; }
        public RoverCount RoverCount { get; set; }
        public List<Rover> Rovers { get; set; }

        public Mission GetMission()
        {
            this.Plateau = new Plateau();
            this.Rovers = new List<Rover>()
                {
                    new Rover()
                };
            this.RoverCount = new RoverCount();

            return this;
        }
    }
}
