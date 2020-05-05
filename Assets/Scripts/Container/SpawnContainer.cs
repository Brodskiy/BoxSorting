using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnContainer : MonoBehaviour, IInitializationSystem
{    
    [SerializeField] private GameObject _containerPrefab;

    private int _quantityContainer;

    private IScreenInfoSystem _screenInfo;
    private Vector3 _containerSize;
    private Vector3 _positionFirstContainer;
    private List<GameObject> _listContainers;
    private GameLevelInspector _gameLevelInspector;

    public void Initialization()
    {
        _screenInfo = IocContainer.Instance.ScreenSystem;
        _gameLevelInspector = FindObjectOfType<GameLevelInspector>();

        _quantityContainer = _gameLevelInspector.CurrentLevel.QuantityColors;
        _gameLevelInspector.OnLevelComplit += UpdateConatiner;
        _listContainers = new List<GameObject>();
        
        SpawnContainers();
    }

    private void UpdateConatiner(LevelModelBase level)
    {
        _quantityContainer = level.QuantityColors;
        SpawnContainers();
    }

    private void SpawnContainers()
    {
        SetContainerSize();
        SetPositionFirstContainer();
        InitContainer();
    }
    
    private void SetContainerSize()
    {
        _containerSize = _screenInfo.ScreenSize / _quantityContainer;
    }

    private void SetPositionFirstContainer()
    {
        _positionFirstContainer = _screenInfo.MinPosition + (_containerSize / 2);
    }

    private void InitContainer()
    {

        for (int i = 0; i < _quantityContainer; i++)
        {
            if (_listContainers.Count > i)
            {
                _listContainers[i].transform.localScale = new Vector3(_containerSize.x, transform.localScale.y);
                _listContainers[i].transform.position = new Vector3(_positionFirstContainer.x, transform.position.y);

                _positionFirstContainer += _containerSize;
            }
            else
            {
                var container = Instantiate(
                    _containerPrefab, 
                    new Vector3(_positionFirstContainer.x, transform.position.y), Quaternion.identity);
                
                container.transform.localScale = new Vector3(_containerSize.x, transform.localScale.y);

                _listContainers.Add(container);

                _positionFirstContainer += _containerSize;

                SetColor(i);
            }
        }
    }

    private void SetColor(int numberContainer)
    { 
        var _changeColor = new GererationColorSystem(numberContainer);

        _listContainers[numberContainer].GetComponent<Renderer>().material.color = _changeColor.ListColors[numberContainer];

        GC.SuppressFinalize(_changeColor);
    }   
}