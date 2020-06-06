using UnityEngine;
using UnityEngine.UI;

public class SceneChangeSystem : MonoBehaviour
{
    [SerializeField] private SceneTransitionSystem _transformationSystem;
    [SerializeField] private Button _btnPlay;
    [SerializeField] private Button _btnLevel;
    [SerializeField] private Button _btnQuit;

    private readonly string _gameScene = "GameScene";
    private readonly string _levelScene = "LevelScene";
   
    private IStatusGameSystem _statusGame; 

    public void RunGameScene()
    {
        _transformationSystem.TransitionToScene(_gameScene);
    }

    private void Start()
    {        
        _btnPlay.onClick.AddListener(PlayButtonClick);        
        _btnQuit.onClick.AddListener(QuitButtonClick);

        if(_btnLevel != null)
        {
            _btnLevel.onClick.AddListener(LevelButtonClick);
        }

    }

    private void QuitButtonClick()
    {
#if UNITY_EDITOR
        Debug.Log("Quit");
#endif

        Application.Quit();
    }

    private void PlayButtonClick()
    {
        ChackIocControllerInstance();
        _transformationSystem.TransitionToScene(_gameScene);
    }

    private void LevelButtonClick()
    {
        ChackIocControllerInstance();
        _transformationSystem.TransitionToScene(_levelScene);        
    }
    private void ChackIocControllerInstance()
    {
        if (IocContainer.Instance != null)
        {
            _statusGame = IocContainer.Instance.GameStatusSystem;
            ChangeGameStatus();
        }
    }

    private void ChangeGameStatus()
    {
        _statusGame.Play();
        _statusGame.IsCanSpawn = false;
        _statusGame.IsCanMove = false;
    }    
}