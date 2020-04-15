using System;
using UnityEngine;
using UnityEngine.UI;

class LevelButtonControler:MonoBehaviour
{
    [SerializeField] private Button _button;

    public int CountNumberLevelButton { get; private set; }
    public bool IsActiveLevelButton { get; private set; }

    private LevelButtonBase _baseButton = new LevelButtonBase();

    public event Action LevelButtonClick;

    private void Start()
    {
        CountNumberLevelButton = _baseButton.CountNumber;
        IsActiveLevelButton = _baseButton.IsActive;

        _button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        LevelButtonClick?.Invoke();
    }

    public void SetCountNumberLevelButton(int countNumber)
    {
        CountNumberLevelButton = countNumber;
    }

    public void SetIsActiveLevelButton(bool isActive)
    {
        IsActiveLevelButton = isActive;
    }
}