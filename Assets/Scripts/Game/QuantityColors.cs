using System;
using UnityEngine;

public class QuantityColors : MonoBehaviour
{
    private int _stepUpdateQuantityColors = 5;
    private int _maxQuanityColors = 4;

    public event Action<int> ChangeQuantityColors;
    public int GetQuantityColors { get; private set; } = 2;

    private void Start()
    {
        FindObjectOfType<GameLevelInspector>().LevelUp += QuantityColors_LevelUp;
    }

    private void QuantityColors_LevelUp(int level)
    {
        if (level >= _stepUpdateQuantityColors)
        {
            if(GetQuantityColors < _maxQuanityColors)
            {
                _stepUpdateQuantityColors += _stepUpdateQuantityColors;
                GetQuantityColors++;
                ChangeQuantityColors?.Invoke(GetQuantityColors);
            }
        }
    }
}
