using System;
using UnityEngine;

public class GameLevelInspector : MonoBehaviour
{    
    public int Level { get; private set; }

    public event Action LevelUp;
   
    private void Start()
    {
        GetComponent<TransitionLevel>().LevelCompleted += GameInspector_LevelCompleted;
        Level = 1;
    }

    private void GameInspector_LevelCompleted()
    {
        Level++;
        LevelUp?.Invoke();
    }    
}