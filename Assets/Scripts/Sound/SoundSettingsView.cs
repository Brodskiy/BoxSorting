using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSettingsView : MonoBehaviour
{
    [SerializeField] private Slider _soundSlider;
    [SerializeField] private Toggle _soundToggle;
    [SerializeField] private Slider _effectsSlider;
    [SerializeField] private Toggle _effectsToggle;
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Toggle _musicToggle;
    [SerializeField] private Button _exitButton;

    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private SoundSettinsController _soundSettinsController;
    [SerializeField] private AudioMixerGroup _audioMixerGroup;
    
    private void Start()
    {
        _exitButton.onClick.AddListener(ExitButtonClick);

        _soundToggle.isOn = _soundSettinsController.SavedAudioInfo.SavedSoundSettings.IsSoundOn;
        _musicToggle.isOn = _soundSettinsController.SavedAudioInfo.SavedSoundSettings.IsMusicOn;
        _effectsToggle.isOn = _soundSettinsController.SavedAudioInfo.SavedSoundSettings.IsEffecsOn;

        _soundSlider.value = _soundSettinsController.SavedAudioInfo.SavedSoundSettings.VolumeSound;
        _musicSlider.value = _soundSettinsController.SavedAudioInfo.SavedSoundSettings.VolumeMusic;
        _effectsSlider.value = _soundSettinsController.SavedAudioInfo.SavedSoundSettings.VolumeEffects;
    }

    private void Update()
    {
        Settings();
    }

    private void Settings()
    {
        ChangeVolumeValue("MasterVolume",_soundSlider.value, _soundToggle.isOn);
        ChangeVolumeValue("EffectsVolume",_effectsSlider.value, _effectsToggle.isOn);
        ChangeVolumeValue("MusicVolume",_musicSlider.value,_musicToggle.isOn);
    }

    private void ChangeVolumeValue(string nameMixer, float volumeValue, bool toggleValue)
    {
        if (toggleValue)
        {
            _audioMixerGroup.audioMixer.SetFloat(nameMixer, Mathf.Lerp(-80, 0, volumeValue));
        }
        else
        {
            _audioMixerGroup.audioMixer.SetFloat(nameMixer, -80);
        }        
    }

    private void ExitButtonClick()
    {
        _settingsPanel.SetActive(false);
        SaveSattings();        
    }

    private void SaveSattings()
    {
        _soundSettinsController.SavedAudioInfo.SavedSoundSettings.IsSoundOn = _soundToggle.isOn;
        _soundSettinsController.SavedAudioInfo.SavedSoundSettings.IsMusicOn = _musicToggle.isOn;
        _soundSettinsController.SavedAudioInfo.SavedSoundSettings.IsEffecsOn = _effectsToggle.isOn;

        _soundSettinsController.SavedAudioInfo.SavedSoundSettings.VolumeSound = _soundSlider.value;
        _soundSettinsController.SavedAudioInfo.SavedSoundSettings.VolumeMusic = _musicSlider.value;
        _soundSettinsController.SavedAudioInfo.SavedSoundSettings.VolumeEffects = _effectsSlider.value;

        _soundSettinsController.SaveData();
    }
}