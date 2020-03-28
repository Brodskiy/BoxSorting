using System;
using UnityEngine;

class InputKeybordSystem : MonoBehaviour, IInputSystem
{
    public event Action<EInputState> OnClicked;
    public event Action OnClickedOff;

    private void Update()
    {
        OnInput();
    }

    public void OnInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            OnClicked?.Invoke(EInputState.Left);
        }

        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            OnClickedOff?.Invoke();
        }

        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            OnClicked?.Invoke(EInputState.Right);
        }

        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            OnClickedOff?.Invoke();
        }

        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            OnClicked?.Invoke(EInputState.Down);
        }

        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            OnClickedOff?.Invoke();
        }
    }


    
}