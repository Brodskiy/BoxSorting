using System.IO;
using UnityEngine;

class SaveLoadAudioInfo : MonoBehaviour
{
    private string _path;

    public SoundSettingsData SavedSoundSettings = new SoundSettingsData();

    public void Load()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        _path = Path.Combine(Application.persistentDataPath, "SavedSoundSettings.json");
#else
        _path = Path.Combine(Application.dataPath, "SavedSoundSettings.json");
#endif
        if (File.Exists(_path))
        {
            SavedSoundSettings = JsonUtility.FromJson<SoundSettingsData>(File.ReadAllText(_path));
        }
        else
        {
            SavedSoundSettings.IsSoundOn = true;
            SavedSoundSettings.IsMusicOn = true;
            SavedSoundSettings.IsEffecsOn = true;
            SavedSoundSettings.VolumeSound = 1;
            SavedSoundSettings.VolumeMusic = 1;
            SavedSoundSettings.VolumeEffects = 1;
        }
    }

    public void SaveData()
    {
        File.WriteAllText(_path, JsonUtility.ToJson(SavedSoundSettings));
    }
}