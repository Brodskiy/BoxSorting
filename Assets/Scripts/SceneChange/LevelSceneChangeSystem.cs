using UnityEngine;
using UnityEngine.UI;

class LevelSceneChangeSystem : MonoBehaviour
{
    [SerializeField] private LevelButtonSpawn _levelButtonSpawn;
    [SerializeField] private SceneTransitionSystem _sceneTransitionSystem;
    [SerializeField] private Button _btnGoBack;

    private readonly string _sceneGame = "GameScene";
    private readonly string _sceneMenu = "MenuScene";

    private void Start()
    {
        _btnGoBack.onClick.AddListener(GoBack);
        foreach (LevelButtonControler button in _levelButtonSpawn.LevelButtons)
        {
            button.GetComponent<Button>().onClick.AddListener(LevelButtonClick);
        }
    }

    private void GoBack()
    {
        _sceneTransitionSystem.TransitionToScene(_sceneMenu);
    }

    private void LevelButtonClick()
    {
        _sceneTransitionSystem.TransitionToScene(_sceneGame);
    }
}