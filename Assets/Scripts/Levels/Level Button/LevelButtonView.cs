using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(LevelButtonControler))]
class LevelButtonView:MonoBehaviour
{
    [SerializeField] private Text _buttonText;
    [SerializeField] private Button _button;

    private LevelButtonControler _levelButtonBase;

    public void ShowInfo()
    {
        _levelButtonBase = GetComponent<LevelButtonControler>();
        _buttonText.text = "Level\n"+_levelButtonBase.CountNumberLevelButton.ToString();
        _button.interactable = _levelButtonBase.IsActiveLevelButton;
    }
}