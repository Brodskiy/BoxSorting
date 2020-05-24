using System.Collections.Generic;
using UnityEngine;

public class ContainerController : MonoBehaviour, IInitializationSystem
{
    const int TWO = 2;

    [SerializeField] private GameLevelInspector _gameLevelInspector;

    private IScreenInfoSystem _screenInfo;
    private int _quantityColors;

    public void Initialization()
    {
        _screenInfo = IocContainer.Instance.ScreenSystem;
        _quantityColors = _gameLevelInspector.CurrentLevel.QuantityColors;

        SetContainersViewList(IocContainer.Instance.SpawnContainerSystem.ListContainers);
    }

    private void SetContainersViewList(List<ContainerView> containers)
    {
        for (int i = 0; i < containers.Count; i++)
        {
            containers[i].SetContainerSize(SetSize(_screenInfo.ScreenSize.x, _quantityColors));
            containers[i].SetContainerPosition(SetPosition(i + 1, containers[i].ContainerSize));
            containers[i].SetContainerColor(SetColor(i));

            containers[i].SettingPrefab();
        }
    }

    private Color SetColor(int numberContainer)
    {
        var color = new GererationColorSystem(_quantityColors).ListColors[numberContainer];
        return color;
    }

    private float SetSize(float screenSizeX, int quantityColors)
    {
        return screenSizeX / quantityColors;
    }

    private Vector3 SetPosition(int numberContainer, float containerSize)
    {
        return new Vector3((
            containerSize * numberContainer - containerSize / TWO) + _screenInfo.MinPosition.x,
            _screenInfo.MinPosition.y);
    }
}