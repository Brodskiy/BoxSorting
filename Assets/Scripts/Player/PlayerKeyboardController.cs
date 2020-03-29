using UnityEngine;

public class PlayerKeyboardController : MonoBehaviour
{
    private PlayerMoves _playerMoves;

    void Start()
    {
        _playerMoves = _playerMoves == null ? FindObjectOfType<PlayerMoves>().GetComponent<PlayerMoves>() : _playerMoves;
        
        IocContainer.Instance.InputSystem.OnClicked += _input_OnClicked;
        IocContainer.Instance.InputSystem.OnClickedOff += _input_OnClickedOff;

        IocContainer.Instance.InputButtonSystem.OnClicked += _input_OnClicked;
        IocContainer.Instance.InputButtonSystem.OnClickedOff += _input_OnClickedOff;
    }   

    private void _input_OnClicked(EInputState inputValue)
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

    private void _input_OnClickedOff()
    {
        _playerMoves.Stay();
    }
}
