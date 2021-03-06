﻿using UnityEngine;

class MoveBonusPackage : MoveBasePackage
{
    [SerializeField] protected float _bonusPackaegSpeed = 5;
    private void Awake()
    {
        _speed = _bonusPackaegSpeed;
    }
    private void Update()
    {
        Move();
    }
    protected override void Move()
    {
        if (IocContainer.Instance.GameStatusSystem.IsCanMove)
        {
            Vector3 temp = transform.position;
            temp.y -= _speed * Time.deltaTime;
            transform.position = temp;
        }        
    }
}