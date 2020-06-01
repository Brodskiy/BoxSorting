using System.IO;
using UnityEngine;

public class SaveLoadLives : MonoBehaviour, ILiveLoader
{
    public LiveData LiveDataInfo { get; set;}

    private string _path;

    public void Initialization()
    {
        LiveDataInfo = new LiveData();

#if UNITY_ANDROID && !UNITY_EDITOR
        _path = Path.Combine(Application.persistentDataPath, "SaveLives.json");
#else
        _path = Path.Combine(Application.dataPath, "SaveLives.json");
#endif
        if (File.Exists(_path))
        {
            LiveDataInfo = JsonUtility.FromJson<LiveData>(File.ReadAllText(_path));
        }
        else
        {
            LiveDataInfo.Lives = 3;
        }
    }

    public void SaveData()
    {
        File.WriteAllText(_path, JsonUtility.ToJson(LiveDataInfo));
    }
}