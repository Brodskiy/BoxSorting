public class BaseLevel:LevelModelBase
{
	public BaseLevel(float timeSpawnParcel, float levelTimer, int quantityColors, float parcelSpeed)
	{
		TimeSpawnParcel = timeSpawnParcel;
		LevelTimer = levelTimer;
		QuantityColors = quantityColors;
		ParcelSpeed = parcelSpeed;
		IsOpen = false;
	}
}