using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(LevelButtonBase))]

class LevelButtonView:MonoBehaviour
{
    [SerializeField] private Text _buttonText;

    private LevelButtonBase _levelButtonBase;
    private Button _button;

    private void Start()
    {
        _levelButtonBase = GetComponent<LevelButtonBase>();
        _buttonText.text = _levelButtonBase.CountNumber.ToString();
        _button.interactable = _levelButtonBase.IsActive;
    }
}