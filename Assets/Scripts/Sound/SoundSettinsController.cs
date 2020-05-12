using UnityEngine;

class SoundSettinsController : MonoBehaviour
{
    public SaveLoadAudioInfo SavedAudioInfo;

    private void Awake()
    {
        SavedAudioInfo.Load();
    }

    public void SaveData()
    {
        SavedAudioInfo.SaveData();
    }
}