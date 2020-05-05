using UnityEngine;

public class FloorSizeView : MonoBehaviour, IInitializationSystem
{
    public void Initialization()
    {
        SetFloorSize();
    }

    private void SetFloorSize()
    {
        transform.localScale = new Vector3(IocContainer.Instance.ScreenSystem.ScreenSize.x, transform.localScale.y);
    }   
}