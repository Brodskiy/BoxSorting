using System.IO;
using UnityEngine;

class SaveLoadLevel:MonoBehaviour
{    
    private string _path;

    public SaveLevelData _saveLevelData = new SaveLevelData();

    public void Load()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        _path = Path.Combine(Application.persistentDataPath, "SaveLevel.json");
#else
        _path = Path.Combine(Application.dataPath, "SaveLevel.json");
#endif
        if (File.Exists(_path))
        {
            _saveLevelData = JsonUtility.FromJson<SaveLevelData>(File.ReadAllText(_path));
        }
        else
        {
            _saveLevelData.ActiveLevels = 1;
        }
    }

    public void SaveData()
    {
        _saveLevelData.ActiveLevels = FindObjectOfType<GameLevelInspector>()._activeLevel;
        File.WriteAllText(_path, JsonUtility.ToJson(_saveLevelData));
    }
}