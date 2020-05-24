public class BaseLevel:LevelModelBase
{
	public BaseLevel(float timeSpawnParcel, float levelTimer, int quantityColors, float parcelSpeed, bool isCanSpawnDumbbell, bool isCanSpawnHeard)
	{
		TimeSpawnBox = timeSpawnParcel;
		LevelTimer = levelTimer;
		QuantityColors = quantityColors;
		BoxSpeed = parcelSpeed;
		IsOpen = false;
		IsCanSpawnDumbbell = isCanSpawnDumbbell;
		IsCanSpawnHeard = isCanSpawnHeard;
	}
}