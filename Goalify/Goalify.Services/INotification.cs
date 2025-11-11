namespace Goalify.Services
{
    public interface INotification
    {
        Task SendNotification(string title, string message);
    }
}
