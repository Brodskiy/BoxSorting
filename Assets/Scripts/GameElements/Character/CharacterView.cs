using UnityEngine;

public class CharacterView : BaseGameElement
{
    private IScreenInfoSystem _screenInfo; 

    public override Vector3 GetSpawnPosition()
    {
        _screenInfo = IocContainer.Instance.ScreenSystem;
        return new Vector3(_screenInfo.ScreenSize.x / 2 + _screenInfo.MinPosition.x, transform.position.y);
    }
}