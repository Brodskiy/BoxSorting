using System;
using UnityEngine;

public class CatchBox : MonoBehaviour
{
    private BoxContainerSystem _box;

    public event Action<BoxContainerSystem> CaughtBox;
    public bool _isHandsFree = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<BoxContainerSystem>())
        {
            if (_isHandsFree)
            {
                _box = collision.GetComponent<BoxContainerSystem>();
                collision.GetComponent<BoxController>().IsCaught(true);

                _box._boxController.IsCaught(true);
                _box._moveBox.IsBoxStop=true;

                _isHandsFree = false;

                CaughtBox?.Invoke(_box);
            }
        }
    }
}