using UnityEngine;
using UnityEngine.UI;

class SettingsButtonView : MonoBehaviour
{
    [SerializeField] private GameObject _settingPanel;
    [SerializeField] private Button _settingButon;
    
    private void Start()
    {
        _settingButon.onClick.AddListener(ActivateSettingPanel);
    }

    private void ActivateSettingPanel()
    {
        _settingPanel.SetActive(true);
    }
}