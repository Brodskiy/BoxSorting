using System.Collections.Generic;
using UnityEngine;

public class ContainerController : MonoBehaviour, IInitializationSystem
{
    const int TWO = 2;

    [SerializeField] private GameLevelInspector _gameLevelInspector;

    private float _screenSizeX;
    private int _quantityColors;

    public void Initialization()
    {
        _screenSizeX = IocContainer.Instance.ScreenSystem.ScreenSize.x;
        _quantityColors = _gameLevelInspector.CurrentLevel.QuantityColors;

        SetContainersViewList(IocContainer.Instance.spawnContainerSystem.ListContainers);

    }

    private void SetContainersViewList(List<ContainerView> containers)
    {
        for (int i = 0; i < containers.Count; i++)
        {
            containers[i].SetContainerSize(SetSize(_screenSizeX, _quantityColors));
            containers[i].SetContainerPosition(SetPosition(i + 1, containers[i].ContainerSize));
            containers[i].SetContainerColor(SetColor(i));

            containers[i].SettingPrefab();
        }
    }

    private Color SetColor(int numberContainer)
    {
        var color = new GererationColorSystem(IocContainer.Instance.GameLevel.CurrentLevel.QuantityColors).ListColors[numberContainer];
        return color;
    }

    private float SetSize(float screenSizeX, int quantityColors)
    {
        return screenSizeX / quantityColors;
    }

    private Vector3 SetPosition(int numberContainer, float containerSize)
    {
        return new Vector3((containerSize * numberContainer - containerSize / TWO) + IocContainer.Instance.ScreenSystem.MinPosition.x,
            IocContainer.Instance.ScreenSystem.MinPosition.z/TWO);
    }
}