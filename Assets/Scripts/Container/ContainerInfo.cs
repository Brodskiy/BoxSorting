using UnityEngine;

public class ContainerInfo : MonoBehaviour
{
    public Color ContainerColor { get; private set; }

    public void SetContainerColor(Color color)
    {
        ContainerColor = color;
    }
}