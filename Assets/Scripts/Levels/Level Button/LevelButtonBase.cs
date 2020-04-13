using System;
using UnityEngine;
using UnityEngine.UI;

class LevelButtonBase:LevelButtonModel
{
	[SerializeField] private Button _levelButton;

	public Action<int> LevelSelected;

	private void Start()
	{
		_levelButton.onClick.AddListener(LevelButtonClick);
	}

	private void LevelButtonClick()
	{
		LevelSelected?.Invoke(CountNumber);
	}
}