using UnityEngine;

public class DeactivePackage : MonoBehaviour
{
    private void Update()
    {
        ChackDeactivePosition();
    }

    private void ChackDeactivePosition()
    {
        if (transform.position.y < IocContainer.Instance.ScreenSystem.MinPosition.y - transform.localScale.y)
        {
            GetComponent<BasePackage>().Deactivation();
        }
    }
}