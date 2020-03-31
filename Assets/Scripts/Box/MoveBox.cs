using UnityEngine;

public class MoveBox : MonoBehaviour
{
    private float Speed { get; set; }

    public bool IsBoxStop { get; set; }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        SetSpeedMove();

        if (IsBoxStop)
        {
            MoveWithPlayer();            
            return;
        }

        Vector3 temp = transform.position;
        temp.y -= Speed * Time.deltaTime;
        transform.position = temp;
    }

    private void MoveWithPlayer()
    {
        transform.position = FindObjectOfType<PlayerMoves>().BoxPositionInPlayerHands.position;
    }

    private void SetSpeedMove()
    {
        Speed = FindObjectOfType<SpeedBox>().Speed;
    }
}