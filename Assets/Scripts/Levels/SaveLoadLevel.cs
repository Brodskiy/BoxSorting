﻿using System.IO;
using UnityEngine;

class SaveLoadLevel:MonoBehaviour
{
    public SaveLevelData SavedLevelData = new SaveLevelData();

    private string _path;

    public void Load()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        _path = Path.Combine(Application.persistentDataPath, "SaveLevel.json");
#else
        _path = Path.Combine(Application.dataPath, "SaveLevel.json");
#endif
        if (File.Exists(_path))
        {
            SavedLevelData = JsonUtility.FromJson<SaveLevelData>(File.ReadAllText(_path));
        }
        else
        {
            SavedLevelData.ActiveLevels = 1;
            SavedLevelData.SelectedLevel = 1;
        }
    }

    public void SaveData()
    {
        File.WriteAllText(_path, JsonUtility.ToJson(SavedLevelData));
    }
}