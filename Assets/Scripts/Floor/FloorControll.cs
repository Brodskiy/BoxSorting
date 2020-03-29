using UnityEngine;

public class FloorControll : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<BoxController>() != null)
        {
            if (!collision.gameObject.GetComponent<BoxController>().InfoData.WasCaught)
            {
                collision.gameObject.SetActive(false);
                collision.gameObject.GetComponent<BoxController>().IsActive(false);
                FindObjectOfType<GameLiveInspector>().LiveIsLost();
            }            
        }
    }
}