using UnityEngine;

public class DeactiveBox : MonoBehaviour
{
    [SerializeField] private BoxContainerSystem _box;

    private Vector2 _startScaleBox = new Vector2(0.4f, 0.4f);

    private void Update()
    {
        ChackDeactivePosition();
    }

    private void ChackDeactivePosition()
    {
        if (transform.position.y < IocContainer.Instance.ScreenSystem.MinPosition.y - transform.localScale.y)
        {
            _box._moveBox.IsThrowBox = false;
            _box.transform.localScale = _startScaleBox;
            _box._boxController.IsCaught(false);
            _box._boxController.IsActive(false);
        }
    }
}