using System;

namespace MarsRover.Model
{
    public class Rover : BaseModel
    {
        public RoverInfo Info { get; set; }
        public RoverMove Moves { get; set; }
        
        public Rover()
        {

        }

        public virtual void TurnLeft()
        {
            this.Info.Direction = GetCoordinate(this.Info.Direction, -1);
        }

        public void TurnRight()
        {
            this.Info.Direction = GetCoordinate(this.Info.Direction, 1);
        }

        public virtual void Move()
        {
            switch (this.Info.Direction)
            {
                case Compass.N:
                    this.Info.Y += 1;
                    break;
                case Compass.E:
                    this.Info.X += 1;
                    break;
                case Compass.S:
                    this.Info.Y -= 1;
                    break;
                case Compass.W:
                    this.Info.X -= 1;
                    break;
                default:
                    break;
            }
        }
        Compass GetCoordinate(Compass direction, int step)
        {
            int result = (Convert.ToInt32(direction) + step) % 4;

            if (result < 0)
                result += 4;

            return (Compass)result;
        }
    }
}
