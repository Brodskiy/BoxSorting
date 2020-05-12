using UnityEngine;
using UnityEngine.Audio;

class LevelMusicVolume : MonoBehaviour
{
    [SerializeField] private SaveLoadAudioInfo _saveLoadAudioInfo;
    [SerializeField] private AudioMixerGroup _mixer;
    [SerializeField] private AudioSource _sourceMusic;

    private void Start()
    {
        _saveLoadAudioInfo.Load();

        if (_saveLoadAudioInfo.SavedSoundSettings.IsMusicOn)
        {
            float f = Mathf.Lerp(-80, 0, _saveLoadAudioInfo.SavedSoundSettings.VolumeMusic);
            _mixer.audioMixer.SetFloat("MusicVolume", f);
            _sourceMusic.Play();
        }        
    }
}