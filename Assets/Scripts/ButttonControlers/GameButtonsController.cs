using System;
using UnityEngine;

public class GameButtonsController : MonoBehaviour, IInputSystem
{
    public event Action<EInputState> OnClicked;
    public event Action OnClickedOff;

    public void OnButtonLeftDown()
    {
        OnClicked?.Invoke(EInputState.Left);
    }    

    public void OnButtonRightDown()
    {
        OnClicked?.Invoke(EInputState.Right);
    }

    public void OnButtonThrowDown()
    {
        OnClicked?.Invoke(EInputState.Down);
    }

    public void OnButtonUp()
    {
        OnClickedOff?.Invoke();
    }
}