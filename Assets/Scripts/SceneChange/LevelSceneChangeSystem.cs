using UnityEngine;
using UnityEngine.UI;

class LevelSceneChangeSystem:MonoBehaviour
{
    [SerializeField] private LevelButtonSpawn _levelButtonSpawn;
    [SerializeField] private SceneTransitionSystem _sceneTransitionSystem;
    
    private readonly string _gameScene = "GameScene";

    private void Start()
    {
        foreach (LevelButtonControler button in _levelButtonSpawn.LevelButtons)
        {
            button.GetComponent<Button>().onClick.AddListener(LevelButtonClick);
        }
    }

    private void LevelButtonClick()
    {
        _sceneTransitionSystem.TransitionToScene(_gameScene);
    }
}