using UnityEngine;
using UnityEngine.UI;

class DisplayInfo : MonoBehaviour
{
    [SerializeField] private Text _textDisplayInfo;

    public void DisplayText(float value)
    {
        _textDisplayInfo.text = value.ToString("1");
    }

    public void DisplayText(float value, string text)
    {
        _textDisplayInfo.text = text + "\n" + value.ToString("0"); 
    }
}