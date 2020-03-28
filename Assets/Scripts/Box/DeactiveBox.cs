using UnityEngine;

public class DeactiveBox : MonoBehaviour
{
    private ScreenInfo _screenInfo;
    private void Start()
    {
        _screenInfo = FindObjectOfType<ScreenInfo>().GetComponent<ScreenInfo>();
    }

    private void Update()
    {
        ChackDeactivePosition();
    }

    private void ChackDeactivePosition()
    {
        if (transform.position.y < _screenInfo.MinPosition.y - transform.localScale.y)
        {
            gameObject.GetComponent<BoxInfo>().IsActive(false);
        }
    }
}