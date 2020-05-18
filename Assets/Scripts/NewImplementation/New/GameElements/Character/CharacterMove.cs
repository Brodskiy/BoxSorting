﻿using System;
using UnityEngine;

class CharacterMove : MonoBehaviour
{
    private const float TWO = 2;

    [SerializeField] private float _speed = 10;
    [SerializeField] private float _stapDistance = 0.3f;

    private EInputState _direction = EInputState.None;
    
    public event Action ThrowBoxDown;

    public Transform BoxPositionInPlayerHands;

    private float _temp;
    private float _minPositionX;
    private float _maxPositionX;
    
    private bool _isMoveLeft;    

    private void Start()
    {
        _isMoveLeft = false;
        _temp = transform.position.x;
        
        var halfPlayer = transform.localScale.x / TWO;
        
        _minPositionX = IocContainer.Instance.ScreenSystem.MinPosition.x + halfPlayer;
        _maxPositionX = IocContainer.Instance.ScreenSystem.MaxPosition.x - halfPlayer;
    }

    private void Update()
    {
        if (_direction == EInputState.None)
        {
            return;
        }

        Move();
    }

    public void MoveLeft()
    {
        if (!_isMoveLeft)
        {
            MirrorPlayer();
            _isMoveLeft = true;
        }

        _direction = EInputState.Left;
    }

    public void MoveRight()
    {
        if (_isMoveLeft)
        {
            MirrorPlayer();
            _isMoveLeft = false;
        }

        _direction = EInputState.Right;
    }

    public void Stay()
    {
        _direction = EInputState.None;
    }

    public void ThrowBox()
    {
        ThrowBoxDown?.Invoke();
    }

    private void Move()
    {
        if (_direction == EInputState.Left)
        {
            _temp -= _stapDistance * _speed * Time.deltaTime;
        }

        if (_direction == EInputState.Right)
        {
            _temp += _stapDistance * _speed * Time.deltaTime;
        }

        _temp = Mathf.Clamp(_temp, _minPositionX, _maxPositionX);
        transform.position = new Vector3(_temp, transform.position.y, -1);
    }

    private void MirrorPlayer()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y);
    }
}