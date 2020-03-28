using UnityEngine;

public class FloorConfig : MonoBehaviour, IContainerSystem
{
    private ScreenInfo _screenInfo;

    private void SetFloorSize()
    {
        transform.localScale = new Vector3(_screenInfo.ScreenSize.x, transform.localScale.y);
    }

    public void Init()
    {
        _screenInfo = FindObjectOfType<ScreenInfo>().GetComponent<ScreenInfo>();
        SetFloorSize();
    }
}