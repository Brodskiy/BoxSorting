using UnityEngine;

public class FloorView : BaseGameElement
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