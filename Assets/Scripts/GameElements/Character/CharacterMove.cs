﻿using System;
using UnityEngine;

class CharacterMove : MonoBehaviour
{
    private const float TWO = 2;
    private readonly float _stapDistance = 4f;    
    
    public event Action ThrowBoxDown;

    public Transform BoxPositionInPlayerHands;

    private EInputState _direction = EInputState.None;

    private float _temp;
    private float _minPositionX;
    private float _maxPositionX;    
    private bool _isMoveLeft;    

    private void Start()
    {
        _isMoveLeft = false;
        _temp = transform.position.x;
        
        var halfPlayer = transform.localScale.x / TWO;

        var _sceenSystem = IocContainer.Instance.ScreenSystem;

        _minPositionX = _sceenSystem.MinPosition.x + halfPlayer;
        _maxPositionX = _sceenSystem.MaxPosition.x - halfPlayer;
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
            _temp -= _stapDistance * Time.deltaTime;
        }

        if (_direction == EInputState.Right)
        {
            _temp += _stapDistance * Time.deltaTime;
        }

        _temp = Mathf.Clamp(_temp, _minPositionX, _maxPositionX);
        transform.position = new Vector3(_temp, transform.position.y);
    }

    private void MirrorPlayer()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y);
    }
}