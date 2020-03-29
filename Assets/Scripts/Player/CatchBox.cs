using System;
using UnityEngine;

public class CatchBox : MonoBehaviour
{
    private MoveBox _moveBox;
    
    public event Action<GameObject> CaughtBox;
    public bool _isHandsFree = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<MoveBox>())
        {
            if (_isHandsFree)
            {
                collision.GetComponent<BoxController>().IsCaught(true);

                _moveBox = collision.GetComponent<MoveBox>();
                
                MoveBoxWithPlayer();

                _isHandsFree = false;

                CaughtBox?.Invoke(collision.gameObject);
            }
        }
    }

    private void MoveBoxWithPlayer()
    {
        _moveBox._isBoxStop = true;
    }
}