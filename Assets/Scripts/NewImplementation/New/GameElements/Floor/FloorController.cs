using UnityEngine;

public class FloorController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<BaseBoxView>() != null)
        {
            if (!collision.gameObject.GetComponent<BaseBoxView>().IsWasCaught)
            {
                collision.gameObject.SetActive(false);
                collision.gameObject.GetComponent<BaseBoxView>().Deactivation();
                FindObjectOfType<GameLiveInspector>().LiveIsLost();
            }            
        }
    }
}