using UnityEngine;

public class ThrowBox : MonoBehaviour
{
    [SerializeField] private CharacterMove _playerMoves;
    
    private CatchBox _catchBox;
    private bool _isBoxOnHand;
    private MoveBox _moveBox;

    private void Start()
    {
        _catchBox = gameObject.GetComponent<CatchBox>();
        _playerMoves.ThrowBoxDown += Throw;
        _catchBox.CaughtBox += Caught;
    }

    private void Throw()
    {
        if (_isBoxOnHand)
        {
            _moveBox.IsBoxStop = false;
            _catchBox._isHandsFree = true;
            _isBoxOnHand = false;
        }
    }    

    private void Caught(MoveBox box)
    {
        _moveBox = box;
        _isBoxOnHand = true;
    }    
}