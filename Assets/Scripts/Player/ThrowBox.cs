using UnityEngine;

public class ThrowBox : MonoBehaviour
{
    [SerializeField] private PlayerMoves _playerMoves;
    
    private CatchBox _catchBox;    
    private MoveBox _boxMove;
    private bool _isBoxOnHand;

    private void Start()
    {
        _catchBox = gameObject.GetComponent<CatchBox>();
        _playerMoves.ThrowBoxDown += _playerMoves_ThrowBoxDown;
        _catchBox.CaughtBox += Caught;
    }

    private void _playerMoves_ThrowBoxDown()
    {
        if (_isBoxOnHand)
        {
            _boxMove.IsBoxStop = false;
            _catchBox._isHandsFree = true;
            _isBoxOnHand = false;
        }
    }    

    private void Caught(BoxContainerSystem box)
    {
        _boxMove = box.GetComponent<MoveBox>();
        _isBoxOnHand = true;
    }    
}