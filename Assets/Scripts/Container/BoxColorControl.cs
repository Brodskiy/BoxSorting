using UnityEngine;

public class BoxColorControl : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<BoxInfo>())
        {
            if(!IsSameColor(collision.gameObject))
            {
                collision.GetComponent<BoxInfo>().IsActive(false);
                FindObjectOfType<GameLiveInspector>().LiveIsLost();
            }
        }
    }

    private bool IsSameColor(GameObject box)
    {
        return gameObject.GetComponent<Renderer>().material.color == box.GetComponent<BoxInfo>().BoxColor;
    }
}