using UnityEngine;

public class MoveBox : MonoBehaviour
{
    private float _speed;
    private GameLevelInspector _gameLevelInspector;

    public bool IsBoxStop { get; set; }

    private void Start()
    {
        _gameLevelInspector = FindObjectOfType<GameLevelInspector>();
        _speed = _gameLevelInspector.CurrentLevel.ParcelSpeed;

        _gameLevelInspector.LevelUp += UpdateSpeed;
    }

    private void UpdateSpeed(LevelModel level)
    {
        _speed = level.ParcelSpeed;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (IsBoxStop)
        {
            MoveWithPlayer();            
            return;
        }

        Vector3 temp = transform.position;
        temp.y -= _speed * Time.deltaTime;
        transform.position = temp;
    }

    private void MoveWithPlayer()
    {
        transform.position = FindObjectOfType<PlayerMoves>().BoxPositionInPlayerHands.position;
    }
}