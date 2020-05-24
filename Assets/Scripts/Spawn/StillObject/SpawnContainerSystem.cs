using System.Collections.Generic;

public class SpawnContainerSystem : SpawnStillObject
{
    public List<ContainerView> ListContainers;
    public override void Initialization()
    {
        ListContainers = new List<ContainerView>();

        for (int i = 0; i < IocContainer.Instance.GameLevel.CurrentLevel.QuantityColors; i++)
        {
            ListContainers.Add(SpawnObject<ContainerView>(_gameElementPref));
        }
    }
}