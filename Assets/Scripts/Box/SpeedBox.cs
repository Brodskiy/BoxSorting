using UnityEngine;

public class SpeedBox : MonoBehaviour
{
    private float _maxSpeed = 9;

    public float Speed { get; private set; }

    private void Start()
    {
        Speed = 4;
        FindObjectOfType<GameLevelInspector>().LevelUp += _gameLevelInspector_LevelUp;
    }

    private void _gameLevelInspector_LevelUp(int level)
    {
        if (Speed < _maxSpeed)
        {
            Speed++;
        }
    }
}