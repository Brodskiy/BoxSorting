using UnityEngine;

public class FloorControll : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<BoxInfo>() != null)
        {
            if (!collision.gameObject.GetComponent<BoxInfo>().WasCaught)
            {
                collision.gameObject.SetActive(false);
                collision.gameObject.GetComponent<BoxInfo>().IsActive(false);
                FindObjectOfType<GameLiveInspector>().LiveIsLost();
            }            
        }
    }
}