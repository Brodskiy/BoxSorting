using UnityEngine;
using UnityEngine.UI;

public class SceneChangeSystem : MonoBehaviour
{
    [SerializeField] private SceneTransitionSystem _transformationSystem;
    [SerializeField] private Button _btnPlay;
    [SerializeField] private Button _btnLevel;
    [SerializeField] private Button _btnQuit;

    private string _gameScene = "GameScene";
    private string _levelScene = "LevelScene";

    public void RunGameScene()
    {
        _transformationSystem.TransitionToScene(_gameScene);
    }

    private void Start()
    {
        _btnPlay.onClick.AddListener(PlayButtonClick);
        _btnLevel.onClick.AddListener(LevelButtonClick);
        _btnQuit.onClick.AddListener(QuitButtonClick);
    }

    private void QuitButtonClick()
    {
        Application.Quit();
    }

    private void PlayButtonClick()
    {
        _transformationSystem.TransitionToScene(_gameScene);
    }

    private void LevelButtonClick()
    {
        _transformationSystem.TransitionToScene(_levelScene);
    }
}