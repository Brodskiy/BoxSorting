using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(LevelButtonBase))]
class LevelButtonView:MonoBehaviour
{
    [SerializeField] private Text _buttonText;
    [SerializeField] private Button _button;

    private LevelButtonBase _levelButtonBase;

    public void ShowInfo()
    {
        _levelButtonBase = GetComponent<LevelButtonBase>();
        _buttonText.text = "Level\n"+_levelButtonBase.CountNumber.ToString();
        _button.interactable = _levelButtonBase.IsActive;
    }
}