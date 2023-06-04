namespace RideSharingPlatform.Microservices.IncidentManagement.DAL.Interface
{
    public interface IUser
    {
        bool Authenticate(string username, string password);
    }
}
