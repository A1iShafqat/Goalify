namespace Goalify.Services.ConnectivityService;

public interface IConnectivityService
{
    bool IsConnected { get; }
    void StartMonitoring();
    void StopMonitoring();
}
