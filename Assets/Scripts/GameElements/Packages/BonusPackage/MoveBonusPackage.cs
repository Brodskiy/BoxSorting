using UnityEngine;

class MoveBonusPackage : MoveBasePackage
{
    private void Awake()
    {
        _speed = 5;
    }
    private void Update()
    {
        Move();
    }
    protected override void Move()
    {
        Vector3 temp = transform.position;
        temp.y -= _speed * Time.deltaTime;
        transform.position = temp;
    }
}