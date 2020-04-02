using System;
using UnityEngine;

public class GameLevelInspector : MonoBehaviour
{
    [SerializeField] private TransitionLevel _transitionLevel;

    public event Action<int> LevelUp;

    public int Level { get; private set; }
       
    private void Start()
    {
        _transitionLevel.LevelCompleted += GameInspector_LevelCompleted;
        Level = 1;
    }

    private void GameInspector_LevelCompleted()
    {
        Level++;
        LevelUp?.Invoke(Level);
    }    
}