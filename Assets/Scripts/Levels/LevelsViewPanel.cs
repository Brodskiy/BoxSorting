using UnityEngine;
using UnityEngine.EventSystems;

public class LevelsViewPanel : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private LevelModel[] _gameLevels;

    public void Show()
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