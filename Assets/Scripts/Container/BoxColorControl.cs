using UnityEngine;

public class BoxColorControl : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<BoxController>())
        {
            if(!IsSameColor(collision.gameObject))
            {
                collision.GetComponent<BoxController>().IsActive(false);
                FindObjectOfType<GameLiveInspector>().LiveIsLost();
            }
        }
    }

    private bool IsSameColor(GameObject box)
    {
        return gameObject.GetComponent<Renderer>().material.color == box.GetComponent<BoxController>().InfoData.BoxColor;
    }
}