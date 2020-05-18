using System.Collections.Generic;
using UnityEngine;

public class SpawnContainerSystem : SpawnStillObject
{
    [SerializeField] private ContainerView _container;

    public List<ContainerView> ListContainers;
    public override void Init()
    {
        ListContainers = new List<ContainerView>();

        for (int i = 0; i < IocContainer.Instance.GameLevel.CurrentLevel.QuantityColors; i++)
        {
            ListContainers.Add(SpawnObject<ContainerView>(_container));
        }
    }
}