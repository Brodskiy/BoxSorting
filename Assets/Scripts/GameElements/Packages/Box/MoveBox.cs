using UnityEngine;

public class MoveBox : MoveBasePackage
{    
    public bool IsBoxStop { get; set; }
    public bool IsThrowBox { get; set; }

    private readonly float _stapScale = 0.01f;

    private void Awake()
    {
        _gameLevelInspector = IocContainer.Instance.GameLevel;
        _speed = _gameLevelInspector.CurrentLevel.BoxSpeed;
    }

    private void Update()
    {
        Move();
    }

    protected override void Move()
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
                _speed = _gameLevelInspector.CurrentLevel.BoxSpeed;

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
        _speed = 0;
        IsThrowBox = true;
    }
}