using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(LevelButtonControler))]
class LevelButtonView : MonoBehaviour
{
    [SerializeField] private Text _buttonText;
    [SerializeField] private Button _button;

    private SaveLoadLevel _saveLoadLevel;
    private LevelButtonControler _levelButtonBase;
    private int _selectedLevel;

    public void ShowInfo()
    {
        _levelButtonBase = GetComponent<LevelButtonControler>();
        _buttonText.text = "Level\n" + (_levelButtonBase.CountNumberLevelButton + 1).ToString();
        _selectedLevel = _levelButtonBase.CountNumberLevelButton;
        _button.interactable = _levelButtonBase.IsActiveLevelButton;

        Subscription();
    }

    private void Subscription()
    {
        GetComponent<Button>().onClick.AddListener(SetSelectedLevel);
    }

    private void SetSelectedLevel()
    {
        _saveLoadLevel = FindObjectOfType<SaveLoadLevel>();
        _saveLoadLevel.SavedLevelData.SelectedLevel = _selectedLevel;
        _saveLoadLevel.SaveData();
    }
}