using UnityEngine;

public class DeactiveBox : MonoBehaviour
{
    private void Update()
    {
        ChackDeactivePosition();
    }

    private void ChackDeactivePosition()
    {
        if (transform.position.y < IocContainer.Instance.ScreenSystem.MinPosition.y - transform.localScale.y)
        {
            gameObject.SetActive(false);
        }
    }
}