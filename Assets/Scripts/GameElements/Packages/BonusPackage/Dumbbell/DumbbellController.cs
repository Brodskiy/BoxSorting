using UnityEngine;

class DumbbellController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<CharacterView>())
        {
            GetComponent<DumbbellView>().Deactivation();
            IocContainer.Instance.LiveContrller.LiveIsLost(IocContainer.Instance.LiveLoader.LiveDataInfo.Lives);
        }
    }
}