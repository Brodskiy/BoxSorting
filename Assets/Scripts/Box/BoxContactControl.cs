using System;
using UnityEngine;

public class BoxContactControl : MonoBehaviour
{
    public event Action BoxCrash;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ContainerInfo>())
        {
            if (!IsSameColor(collision.GetComponent<ContainerInfo>()))
            {
                GetComponent<BoxController>().IsActive(false);
                FindObjectOfType<GameLiveInspector>().LiveIsLost();
                BoxCrash?.Invoke();
            }
        }
    }

    private bool IsSameColor(ContainerInfo container)
    {
        return GetComponent<BoxContainerSystem>()._boxController.InfoData.BoxColor == container.ContainerColor;
    }
}