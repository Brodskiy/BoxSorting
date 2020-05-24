using System;
using UnityEngine;

public class CatchBox : MonoBehaviour
{
    public event Action<MoveBox> CaughtBox;

    public bool _isHandsFree = true;

    private MoveBox _moveBox;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<BaseBoxView>())
        {
            if (_isHandsFree)
            {
                collision.GetComponent<BaseBoxView>().IsCaught(true);

                _moveBox = collision.GetComponent<MoveBox>();
                _moveBox.IsBoxStop = true;

                _isHandsFree = false;

                CaughtBox?.Invoke(_moveBox);
            }
        }
    }
}