namespace RideSharingPlatform.Microservices.UserVerification.BLL.Exceptions
{
    public class InvalidPhoneNumber : Exception
    {
        public InvalidPhoneNumber(string message) : base(message) { }
    }
}
