using UnityEngine;

public class ScreenInfo : MonoBehaviour, IContainerSystem
{
    public Vector3 MaxPosition { get; private set; }
    public Vector3 MinPosition { get; private set; }
    public Vector3 ScreenSize { get; private set; }

    private void Update()
    {
        if (Input.deviceOrientation == DeviceOrientation.FaceUp)
        {
            Screen.orientation = ScreenOrientation.Portrait;
        }
    }

    private void SetMaxPosition()
    {
        MaxPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
    }

    private void SetMinPosition()
    {
        MinPosition = Camera.main.ScreenToWorldPoint(new Vector3(0, 0));
    }

    private void SetScreenSize()
    {
        ScreenSize = MaxPosition - MinPosition;
    }

    public void Init()
    {
        gameObject.SetActive(true);

        SetMaxPosition();
        SetMinPosition();
        SetScreenSize();
    }
}