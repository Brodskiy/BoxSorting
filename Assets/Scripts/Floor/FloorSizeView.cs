using UnityEngine;

public class FloorSizeView : MonoBehaviour, IContainerSystem
{
    private void SetFloorSize()
    {
        transform.localScale = new Vector3(IocContainer.Instance.ScreenSystem.ScreenSize.x, transform.localScale.y);
    }

    public void Init()
    {
        SetFloorSize();
    }
}