using UnityEngine;

public class FloorView : BaseGameElement
{
    private IScreenInfoSystem _screenInfo;

    public override Vector3 GetSpawnPosition()
    {
        _screenInfo = IocContainer.Instance.ScreenSystem;
        SetFloorSize();

        return new Vector3(_screenInfo.ScreenSize.x / 2 + _screenInfo.MinPosition.x, 
            transform.position.y);
    }

    private void SetFloorSize()
    {
        transform.localScale = new Vector3(_screenInfo.ScreenSize.x, transform.localScale.y);
    }   
}