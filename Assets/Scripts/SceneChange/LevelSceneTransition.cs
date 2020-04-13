using UnityEngine;
using UnityEngine.UI;

class LevelSceneTransition:MonoBehaviour
{
    [SerializeField] private Image _imageTransition;
    [SerializeField] private LevelButtonSpawn _levelButtonSpawn;

    private void Start()
    {
        foreach (var button in _levelButtonSpawn.LevelButtons)
        {
            //button.LevelSelected
        }
        
    }
}