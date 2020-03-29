using UnityEngine;

public class GameButtonsController : MonoBehaviour
{
    private PlayerMoves _playerMoves;
    void Start()
    {
        _playerMoves = _playerMoves == null 
            ? FindObjectOfType<PlayerMoves>() 
            : _playerMoves;
    }

    public void OnButtonLeft()
    {
        _playerMoves.MoveLeft();
    }

    public void OnButtonRight()
    {
        _playerMoves.MoveRight();
    }

    public void OnButtonDown()
    {
        _playerMoves.ThrowBox();
    }



}
