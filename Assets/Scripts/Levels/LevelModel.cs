public class LevelModel
{
    public float TimeSpawnParcel { get; private set; }
    public float LevelTimer { get; private set; }
    public int QuantityColors { get; private set; }
    public float ParcelSpeed { get; private set; }    

    public LevelModel(float timeSpawnParcel, float levelTimer, int quantityColors, float parcelSpeed)
    {
        TimeSpawnParcel = timeSpawnParcel;
        LevelTimer = levelTimer;
        QuantityColors = quantityColors;
        ParcelSpeed = parcelSpeed;
    }
}