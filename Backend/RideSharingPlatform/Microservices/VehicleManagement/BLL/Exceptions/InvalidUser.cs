namespace RideSharingPlatform.Microservices.VehicleManagement.BLL.Exceptions
{
    public class InvalidUser : Exception
    {
        public InvalidUser(string message) : base(message) { }
    }
}
