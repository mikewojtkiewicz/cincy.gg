using cincy.gg.domain.RustIOEntities;
using cincy.gg.Services;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace cincy.gg.Components.HomeComponents;

public partial class MainHero
{
    #region Injections
    [Inject]
    public IRustIOService RustService { get; set; }
    #endregion

    #region Page Properties
    private Status? serverStatus;
    private float onlinePercentage;
    private bool isServerOnline = false;
    #endregion

    #region Page Overrides

    protected override async Task OnInitializedAsync()
    {
        if(await RustService.CanConnectToServer())
        {
            isServerOnline = true;
            serverStatus = await RustService.GetServiceStatus();
            if (serverStatus is not null)
                onlinePercentage = (float)serverStatus.Players / (float)serverStatus.MaxPlayers * 100;
        }
    }

    #endregion
}
