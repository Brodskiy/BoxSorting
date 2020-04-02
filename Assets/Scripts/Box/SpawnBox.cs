﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBox : MonoBehaviour, IContainerSystem
{
    private const float ZERO = 0;

    [SerializeField] private BoxContainerSystem _prefabBox;
    [SerializeField] private QuantityColors _quantityColors;

    private List<BoxContainerSystem> _listBoxes;
    private float _spawnTime = 5;
    private float _timet;

    private int _quantityColorsBox;

    private float _minPositionX;
    private float _maxPositionX;

    public event Action<BoxContainerSystem> BoxCreated;

    public void Init()
    {
        gameObject.SetActive(true);

        _listBoxes = new List<BoxContainerSystem>();
        _quantityColorsBox = _quantityColors.GetQuantityColors;
        SetInitPosition();
        FindObjectOfType<GameLevelInspector>().LevelUp += SpawnBox_LevelUp;
        _quantityColors.ChangeQuantityColors += SpawnBox_ChangeQuantityColors;
    }

    private void SpawnBox_ChangeQuantityColors(int quantityColors)
    {
        _quantityColorsBox = quantityColors;
    }

    private void Update()
    {
        InitBox();
        _timet += Time.deltaTime;
    }

    private void SetInitPosition()
    {
        var screen = IocContainer.Instance.ScreenSystem;

        _minPositionX = screen.MinPosition.x + (gameObject.transform.localScale.x / 2);
        _maxPositionX = screen.MaxPosition.x - (gameObject.transform.localScale.x / 2);
    }

    private void SpawnBox_LevelUp()
    {
        if (_spawnTime >= 1)
        {
            _spawnTime -= 0.5f;
        }
    }

    private void InitBox()
    {
        if (_timet >= _spawnTime)
        {
            _timet = ZERO;
            InstantiateBox();
        }
    }

    private void InstantiateBox()
    {
        for (int i = 0; i < _listBoxes.Count; i++)
        {
            if (!_listBoxes[i]._boxController.InfoData.WasActive)
            {
                _listBoxes[i]._boxController.Activate(_minPositionX, _maxPositionX, transform.position.y);
                BoxColor(_listBoxes[i]._boxController);
                return;
            }
        }

        BoxContainerSystem newBox =
            Instantiate(_prefabBox,
                new Vector3(UnityEngine.Random.Range(_minPositionX, _maxPositionX), transform.position.y,-1),
                Quaternion.identity);

        BoxColor(newBox._boxController);
        
        _listBoxes.Add(newBox);
        BoxCreated?.Invoke(newBox);
    }

    private void BoxColor(BoxController box)
    {
        box.SetBoxColor(_quantityColorsBox);
        box._backgroundColor.GetComponent<Renderer>().material.color = box.InfoData.BoxColor;
    }
}