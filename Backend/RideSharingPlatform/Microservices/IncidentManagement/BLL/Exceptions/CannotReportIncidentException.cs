namespace RideSharingPlatform.Microservices.IncidentManagement.BLL.Exceptions
{
    public class CannotReportIncidentException : Exception
    {
        public CannotReportIncidentException(string message) : base(message) { }
    }
}
