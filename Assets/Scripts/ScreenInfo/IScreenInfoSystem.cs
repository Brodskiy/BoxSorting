using UnityEngine;

public interface IScreenInfoSystem
{
    Vector3 MaxPosition { get; }
    Vector3 MinPosition { get; }
    Vector3 ScreenSize { get; }
}