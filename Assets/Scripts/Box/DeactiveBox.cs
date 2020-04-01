using UnityEngine;

public class DeactiveBox : MonoBehaviour
{
    [SerializeField] private BoxContainerSystem _box;

    private void Update()
    {
        ChackDeactivePosition();
    }

    private void ChackDeactivePosition()
    {
        if (transform.position.y < IocContainer.Instance.ScreenSystem.MinPosition.y - transform.localScale.y)
        {
            _box._boxController.IsActive(false);
        }
    }
}