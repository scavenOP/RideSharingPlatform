namespace RideSharingPlatform.Microservices.UserVerification.BLL.Exceptions
{
    public class InvalidAadharNumber : Exception
    {
        public InvalidAadharNumber(string message) : base(message) { }
    }
}
