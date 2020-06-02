using UnityEngine;

class HeardController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<CharacterView>())
        {
            GetComponent<HeardView>().Deactivation();
            IocContainer.Instance.LiveContrller.LiveAdd(1);
        }
    }
}