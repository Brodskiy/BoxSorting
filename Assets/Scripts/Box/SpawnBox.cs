using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBox : MonoBehaviour, IContainerSystem
{
    private const float ZERO = 0;

    [SerializeField] private BoxContainerSystem _prefabBox;

    private GameLevelInspector _gameLevelInspector;

    private List<BoxContainerSystem> _listBoxes;
    private float _spawnTime;
    private float _timet;

    private int _quantityColorsBox;

    private float _minPositionX;
    private float _maxPositionX;

    public event Action<BoxContainerSystem> BoxCreated;    

    private void UpdateParcel(LevelModelBase levelInfo)
    {
        _spawnTime = levelInfo.TimeSpawnParcel;
        _quantityColorsBox = levelInfo.QuantityColors;
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

    private void InitBox()
    {
        if (_timet >= _spawnTime)
        {
            _timet = ZERO;

            foreach (var box in _listBoxes)
            {
                if(box._boxController.InfoData.WasActive == false)
                {
                    box._boxController.Activate(_minPositionX, _maxPositionX, transform.position.y);
                    BoxColor(box._boxController);
                    return;
                }
            }

            BoxContainerSystem newBox =
            Instantiate(_prefabBox,
                new Vector3(UnityEngine.Random.Range(_minPositionX, _maxPositionX), transform.position.y, -1),
                Quaternion.identity);

            BoxColor(newBox._boxController);

            _listBoxes.Add(newBox);
            BoxCreated?.Invoke(newBox);
        }
    }

    private void BoxColor(BoxController box)
    {
        box.SetBoxColor(_quantityColorsBox);
        box._backgroundColor.GetComponent<Renderer>().material.color = box.InfoData.BoxColor;
    }

    public void Init()
    {
        gameObject.SetActive(true);
        SetInitPosition();
        _gameLevelInspector = FindObjectOfType<GameLevelInspector>();        

        _listBoxes = new List<BoxContainerSystem>();

        _quantityColorsBox = _gameLevelInspector.CurrentLevel.QuantityColors;
        _spawnTime = _gameLevelInspector.CurrentLevel.TimeSpawnParcel;
        _gameLevelInspector.LevelUp += UpdateParcel;
    }
}