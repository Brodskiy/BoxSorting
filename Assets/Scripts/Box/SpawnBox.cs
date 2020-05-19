﻿using System;
using System.Collections.Generic;
using UnityEngine;

//public class SpawnBox : MonoBehaviour, ISpawnComplit
//{
//    private const float ZERO = 0;

//    [SerializeField] private BoxContainerSystem _prefabBox;

//    public event Action<BoxContainerSystem> BoxCreated;
//    public event Action SpawnComplit;

//    public List<BoxContainerSystem> _listBoxes;

//    private GameLevelInspector _gameLevelInspector;

//    private float _spawnTime;
//    private float _timet;

//    private int _quantityColorsBox;

//    private float _minPositionX;
//    private float _maxPositionX;

//    private void Update()
//    {
//        if (IocContainer.Instance.GameStatusSystem.IsCanSpawn)
//        {
//            _timet += Time.deltaTime;

//            if (_timet >= _spawnTime)
//            {
//                InitBox();
//            }
//        }
//    }

//    public void Initialization()
//    {
//        _listBoxes = new List<BoxContainerSystem>();
//        SetInitPosition();
//        _gameLevelInspector = FindObjectOfType<GameLevelInspector>();

//        _quantityColorsBox = _gameLevelInspector.CurrentLevel.QuantityColors;
//        _spawnTime = _gameLevelInspector.CurrentLevel.TimeSpawnParcel;
//        _gameLevelInspector.OnLevelComplit += UpdateParcel;
//    }

//    private void UpdateParcel(LevelModelBase levelInfo)
//    {
//        _spawnTime = levelInfo.TimeSpawnParcel;
//        _quantityColorsBox = levelInfo.QuantityColors;
//    }

//    private void SetInitPosition()
//    {
//        var screen = IocContainer.Instance.ScreenSystem;

//        _minPositionX = screen.MinPosition.x + (gameObject.transform.localScale.x / 2);
//        _maxPositionX = screen.MaxPosition.x - (gameObject.transform.localScale.x / 2);
//    }

//    private void InitBox()
//    {
//        _timet = ZERO;

//        foreach (var box in _listBoxes)
//        {
//            if (box._boxController.InfoData.WasActive == false && box._boxController.InfoData.WasCaught == false)
//            {
//                box._boxController.Activate(_minPositionX, _maxPositionX, transform.position.y);
//                BoxColor(box);
//                SpawnComplit?.Invoke();
//                return;
//            }
//        }

//        BoxContainerSystem newBox =
//            Instantiate(_prefabBox,
//                        new Vector3(UnityEngine.Random.Range(_minPositionX, _maxPositionX), transform.position.y, -1),
//                        Quaternion.identity);

//        BoxColor(newBox);

//        _listBoxes.Add(newBox);
//        BoxCreated?.Invoke(newBox);
//        SpawnComplit?.Invoke();
//    }

//    private void BoxColor(BoxContainerSystem box)
//    {
//        box._boxController.SetBoxColor(_quantityColorsBox);
//        box._boxController.BoxColor.GetComponent<Renderer>().material.color = box._boxController.InfoData.BoxColor;
//    }
//}