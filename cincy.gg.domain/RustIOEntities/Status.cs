namespace cincy.gg.domain.RustIOEntities;

public class Status
{
    public string Hostname { get; set; } = string.Empty;
    public int Players { get; set; }
    public int MaxPlayers { get; set; }
    public int Sleepers { get; set; }
    public string Level { get; set; } = string.Empty;
    public World World { get; set; } = new();
    public Version Version { get; set; } = new();
    public Env Env { get; set; } = new();
}
