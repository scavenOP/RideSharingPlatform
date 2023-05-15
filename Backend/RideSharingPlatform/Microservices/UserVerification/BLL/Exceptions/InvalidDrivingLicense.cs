namespace RideSharingPlatform.Microservices.UserVerification.BLL.Exceptions
{
    public class InvalidDrivingLicense : Exception
    {
        public InvalidDrivingLicense(string message) : base(message) { }
    }
}
