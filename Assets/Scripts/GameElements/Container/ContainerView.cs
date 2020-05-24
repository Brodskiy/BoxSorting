using UnityEngine;

public class ContainerView : BaseGameElement
{
    public Color ContainerColor { get; private set; }
    public Vector3 ContainerPosition { get; private set; }
    public float ContainerSize { get; private set; }

    public void SettingPrefab()
    {
        GetComponent<Renderer>().material.color = ContainerColor;
        transform.position = ContainerPosition;
        transform.localScale = new Vector2(ContainerSize, transform.localScale.y);
    }

    public override Vector3 GetSpawnPosition()
    {
        return ContainerPosition;
    }

    public void SetContainerColor(Color color)
    {
        ContainerColor = color;        
    }

    public void SetContainerPosition(Vector3 position)
    {
        ContainerPosition = position;        
    }

    public void SetContainerSize(float size)
    {
        ContainerSize = size;        
    }
}