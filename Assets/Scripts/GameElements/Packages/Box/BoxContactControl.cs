using System;
using UnityEngine;

public class BoxContactControl : MonoBehaviour
{
    public event Action BoxCrash;

    private BaseBoxView _boxView;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ContainerView>())
        {
            _boxView = GetComponent<BaseBoxView>();

            if (!IsSameColor(collision.GetComponent<ContainerView>()))
            {
                _boxView.Deactivation();
                FindObjectOfType<GameLiveInspector>().LiveIsLost(1);
                BoxCrash?.Invoke();
            }
        }
    }

    private bool IsSameColor(ContainerView container)
    {
        return _boxView.BoxColor == container.ContainerColor;
    }
}