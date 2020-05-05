using UnityEngine;

public class MoveBox : MonoBehaviour
{
    public float _speed;

    private GameLevelInspector _gameLevelInspector;

    public bool IsBoxStop { get; set; }//todo
    public bool IsThrowBox { get; set; }//todo

    private float _stapScale = 0.01f;

    private void Start()
    {
        _gameLevelInspector = FindObjectOfType<GameLevelInspector>();
        _speed = _gameLevelInspector.CurrentLevel.ParcelSpeed;
        _gameLevelInspector.LevelPassed += UpdateSpeed;
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
            if (transform.position.y <= -3.5f)
            {
                transform.localScale = new Vector3(
                transform.localScale.x - _stapScale,
                transform.localScale.y - _stapScale);
            }
        }

        Vector3 temp = transform.position;
        temp.y -= _speed * Time.deltaTime;
        transform.position = temp;
    }

    private void MoveWithPlayer()
    {
        transform.position = FindObjectOfType<PlayerView>().BoxPositionInPlayerHands.position;
        IsThrowBox = true;
    }
}