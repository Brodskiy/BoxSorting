﻿public class BaseLevel:LevelModel
{
	public BaseLevel(float timeSpawnParcel, float levelTimer, int quantityColors, float parcelSpeed)
	{
		TimeSpawnParcel = timeSpawnParcel;
		LevelTimer = levelTimer;
		QuantityColors = quantityColors;
		ParcelSpeed = parcelSpeed;
	}
}