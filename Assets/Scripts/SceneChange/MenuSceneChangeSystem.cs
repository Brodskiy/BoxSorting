using UnityEngine;
using UnityEngine.UI;

public class MenuSceneChangeSystem : MonoBehaviour
{
    [SerializeField] private SceneTransitionSystem _transformationSystem;
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _levelButton;

    private string _gameScene = "GameScene";
    private string _levelScene = "LevelScene";

    private void Start()
    {
        _playButton.onClick.AddListener(PlayButtonClick);
        _levelButton.onClick.AddListener(LevelButtonClick);
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
