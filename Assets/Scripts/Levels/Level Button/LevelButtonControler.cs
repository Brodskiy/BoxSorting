using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
class LevelButtonControler:MonoBehaviour
{
    public int CountNumberLevelButton { get; private set; }
    public bool IsActiveLevelButton { get; private set; }

    private LevelButtonBase _baseButton;

    private void Start()
    {
        _baseButton = new LevelButtonBase();
        CountNumberLevelButton = _baseButton.CountNumber;
        IsActiveLevelButton = _baseButton.IsActive;
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