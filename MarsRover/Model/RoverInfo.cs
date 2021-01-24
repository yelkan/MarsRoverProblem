namespace MarsRover.Model
{
    public class RoverInfo : BaseModel
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Compass Direction { get; set; }
    }
}
