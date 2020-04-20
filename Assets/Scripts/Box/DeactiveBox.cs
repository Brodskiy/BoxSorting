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
            _box._moveBox.IsThrowBox = false;
            _box.transform.localScale = new Vector3(0.4f, 0.4f);
            _box._boxController.IsActive(false);
        }
    }
}