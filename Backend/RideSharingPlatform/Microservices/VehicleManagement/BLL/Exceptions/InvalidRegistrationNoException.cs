namespace RideSharingPlatform.Microservices.VehicleManagement.BLL.Exceptions
{
    public class InvalidRegistrationNoException : Exception
    {
        public InvalidRegistrationNoException(string message) : base(message) { }
    }
}
