using UnityEngine;

public class CharacterKeyboardController : MonoBehaviour
{
    private CharacterMove _playerMoves;

    void Start()
    {
        _playerMoves = _playerMoves == null ? FindObjectOfType<CharacterMove>() : _playerMoves;
        
        IocContainer.Instance.InputSystem.OnClicked += ButtonOnClick;
        IocContainer.Instance.InputSystem.OnClickedOff += ButtonOnCkickOff;

        IocContainer.Instance.InputButtonSystem.OnClicked += ButtonOnClick;
        IocContainer.Instance.InputButtonSystem.OnClickedOff += ButtonOnCkickOff;
    }   

    private void ButtonOnClick(EInputState inputValue)
    {
        switch (inputValue)
        {
            case EInputState.Left:
                _playerMoves.MoveLeft();
                break;

            case EInputState.Right:
                _playerMoves.MoveRight();
                break;

            case EInputState.Down:
                _playerMoves.ThrowBox();
                break;
        }
    }

    private void ButtonOnCkickOff()
    {
        _playerMoves.Stay();
    }
}
