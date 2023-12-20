using cincy.gg.domain.RustIOEntities;

namespace cincy.gg.Services;

public interface IRustIOService
{
    Task<string> GetPlayerData();
    Task<Status?> GetServiceStatus();
    Task<bool> CanConnectToServer();
}
