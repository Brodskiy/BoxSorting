using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LevelsViewPanel : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Transform _conntainer;


    public void Show(IEnumerable<Sprite> sprites)
    {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

}