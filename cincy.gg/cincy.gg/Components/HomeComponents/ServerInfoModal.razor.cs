using cincy.gg.domain.RustIOEntities;
using cincy.gg.Services;
using Microsoft.AspNetCore.Components;

namespace cincy.gg.Components.HomeComponents;

public partial class ServerInfoModal
{
    #region Injections
    [Inject]
    public IRustIOService RustService { get; set; }
    #endregion

    #region Page Properties
    private Status? serverStatus;

    #endregion

    #region Page Overrides

    protected override async Task OnInitializedAsync()
    {
        if(await RustService.CanConnectToServer())
            serverStatus = await RustService.GetServiceStatus();
    }

    #endregion
}
