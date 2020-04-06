using System;
using System.Collections.Generic;
using UnityEngine;

public class GameLevelInspector : MonoBehaviour
{
    public List<LevelModel> GameLevels;

    public event Action<int> LevelUp;

    public int CurrentLevel { get; private set; }
       
    private void Start()
    {
        GameLevels = new List<LevelModel>();
    }

    private void GameInspector_LevelCompleted()
    {
        Level++;
        LevelUp?.Invoke(Level);
    }    
}