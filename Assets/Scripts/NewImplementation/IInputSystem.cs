using System;

public interface IInputSystem
{
    event Action<EInputState> OnClicked;
    event Action OnClickedOff;
}