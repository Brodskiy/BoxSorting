using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnContainer : MonoBehaviour, IContainerSystem
{
    [SerializeField] private GameObject _containerPrefab;
    [SerializeField] private QuantityColors _quantityColors;

    private int _quantityContainer;

    private ScreenInfo _screenInfo;
    private Vector3 _containerSize;
    private Vector3 _positionFirstContainer;
    private List<GameObject> _listContainers;

    public void Init()
    {
        gameObject.SetActive(true);

        _quantityContainer = _quantityColors.GetQuantityColors;
        _listContainers = new List<GameObject>();
        _screenInfo = FindObjectOfType<ScreenInfo>().GetComponent<ScreenInfo>();

        _quantityColors.ChangeQuantityColors += _quantityColors_ChangeQuantityColors;

        SpawnContainers();
    }

    private void _quantityColors_ChangeQuantityColors(int quanityColors)
    {
        _quantityContainer = quanityColors;
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
                _listContainers[i].transform.position = new Vector3(_positionFirstContainer.x, transform.position.y, -8);

                _positionFirstContainer += _containerSize;
            }
            else
            {
                var container = InstatiateContainer();
                container.transform.localScale = new Vector3(_containerSize.x, transform.localScale.y);

                _listContainers.Add(container);

                _positionFirstContainer += _containerSize;

                SetColor(i);
            }
        }
    }

    private GameObject InstatiateContainer()
    {
        return Instantiate(_containerPrefab, new Vector3(_positionFirstContainer.x, transform.position.y, -8), Quaternion.identity);
    }

    private void SetColor(int numberContainer)
    {
        ChangColor _changeColor = new ChangColor(numberContainer);

        _listContainers[numberContainer].GetComponent<Renderer>().material.color = _changeColor.ListColors[numberContainer];

        GC.SuppressFinalize(_changeColor);
    }   
}