using UnityEngine;

public class ScreenInfo : IScreenInfoSystem
{
    public Vector3 MaxPosition { get; }
    public Vector3 MinPosition { get; }
    public Vector3 ScreenSize { get; }

    private Camera _cam;

    public ScreenInfo(Camera cam)
    {
        _cam = cam;
        
        MaxPosition = _cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
        MinPosition = _cam.ScreenToWorldPoint(new Vector3(0, 0));
        
        ScreenSize = MaxPosition - MinPosition;
    }
}