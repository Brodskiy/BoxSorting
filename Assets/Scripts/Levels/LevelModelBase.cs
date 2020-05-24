public class LevelModelBase
{
    public float TimeSpawnBox { get; protected set; }
    public float LevelTimer { get; protected set; }
    public int QuantityColors { get; protected set; }
    public float BoxSpeed { get; protected set; }
    public bool IsOpen { get; set; }
    public bool IsCanSpawnDumbbell { get; protected set; }
    public bool IsCanSpawnHeard { get; protected set; }
}