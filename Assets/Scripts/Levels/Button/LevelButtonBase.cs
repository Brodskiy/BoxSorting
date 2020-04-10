class LevelButtonBase:LevelButtonModel
{
	public LevelButtonBase(int number)
	{
		CountNumber = number;
	}

	public int LevelButtonClick()
	{
		return CountNumber;
	}
}