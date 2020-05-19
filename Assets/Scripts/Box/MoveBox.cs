using UnityEngine;

public class MoveBox : MonoBehaviour
{
    public float _speed;

    private GameLevelInspector _gameLevelInspector;

    public bool IsBoxStop { get; set; }
    public bool IsThrowBox { get; set; }

    private float _stapScale = 0.01f;

    private void Start()
    {
        _gameLevelInspector = IocContainer.Instance.GameLevel;
        _speed = _gameLevelInspector.CurrentLevel.BoxSpeed;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (IocContainer.Instance.GameStatusSystem.IsCanMove)
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
    }

    private void MoveWithPlayer()
    {
        transform.position = FindObjectOfType<CharacterMove>().BoxPositionInPlayerHands.position;
        IsThrowBox = true;
    }
}