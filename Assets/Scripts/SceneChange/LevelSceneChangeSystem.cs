using UnityEngine;

class LevelSceneChangeSystem:MonoBehaviour
{
    [SerializeField] private LevelButtonSpawn _levelButtonSpawn;
    [SerializeField] private SceneTransitionSystem _sceneTransitionSystem;

    private readonly string _gameScene = "GameScene";

    private void Start()
    {
        foreach (LevelButtonControler button in _levelButtonSpawn.LevelButtons)
        {
            button.LevelButtonClick += Button_LevelButtonClick;
        }        
    }

    private void Button_LevelButtonClick()
    {
        _sceneTransitionSystem.TransitionToScene(_gameScene);
    }
}