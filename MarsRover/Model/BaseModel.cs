namespace MarsRover.Model
{
    public abstract class BaseModel
    {
        public bool IsSuccess
        {
            get;set;
        }

        public string ErrorMessage { get; set; }
    }
}
