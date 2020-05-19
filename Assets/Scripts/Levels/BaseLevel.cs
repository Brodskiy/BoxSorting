public class BaseLevel:LevelModelBase
{
	public BaseLevel(float timeSpawnParcel, float levelTimer, int quantityColors, float parcelSpeed)
	{
		TimeSpawnBox = timeSpawnParcel;
		LevelTimer = levelTimer;
		QuantityColors = quantityColors;
		BoxSpeed = parcelSpeed;
		IsOpen = false;
	}
}