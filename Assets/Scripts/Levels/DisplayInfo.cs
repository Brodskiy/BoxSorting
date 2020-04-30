using UnityEngine;
using UnityEngine.UI;

class DisplayInfo : MonoBehaviour
{
    [SerializeField] private Text _textDisplayInfo;

    public void TimerLevelDisplay(float timerValue)
    {
        if (timerValue >= 0)
        {
            _textDisplayInfo.text = timerValue.ToString("0");
        }
    }
}