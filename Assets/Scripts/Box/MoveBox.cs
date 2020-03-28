using UnityEngine;

public class MoveBox : MonoBehaviour
{
    private float _speed;

    public bool _isBoxStop;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        SetSpeedMove();

        if (_isBoxStop)
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

    private void SetSpeedMove()
    {
        _speed = FindObjectOfType<SpeedBox>().Speed;
    }
}