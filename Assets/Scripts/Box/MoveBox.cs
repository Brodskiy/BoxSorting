using UnityEngine;

public class MoveBox : MonoBehaviour
{
    private float _speed;

    private GameLevelInspector _gameLevelInspector;

    public bool IsBoxStop { get; set; }//todo
    public bool IsThrowBox { get; set; }//todo

    private void Start()
    {
        _gameLevelInspector = FindObjectOfType<GameLevelInspector>();
        _speed = _gameLevelInspector.CurrentLevel.ParcelSpeed;
        _gameLevelInspector.LevelUp += UpdateSpeed;
    }

    private void UpdateSpeed(LevelModelBase level)
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

        if (IsThrowBox)
        {
            if(transform.position.y <= -3.5f)
            {
                transform.localScale = new Vector3(
                transform.localScale.x - 0.02f,
                transform.localScale.y - 0.02f);
            }
            else
            {
                transform.localScale = new Vector3(
                transform.localScale.x + 0.01f,
                transform.localScale.y + 0.01f);
            }            
        }

        Vector3 temp = transform.position;
        temp.y -= _speed * Time.deltaTime;
        transform.position = temp;
    }

    private void MoveWithPlayer()
    {
        transform.position = FindObjectOfType<PlayerMoves>().BoxPositionInPlayerHands.position;
        IsThrowBox = true;
    }
}