using UnityEngine;

public class IocContainer : MonoBehaviour
{
    public static IocContainer Instance { get; private set; }

    [SerializeField] private SpawnBox _spawnBoxManager;
    [SerializeField] private SpawnContainer _container;
    [SerializeField] private InputKeybordSystem _inputKeybordSystem;
    [SerializeField] private GameButtonsController _gameButtonsController;
    [SerializeField] private GameStatusController _gameStatusController;
    [SerializeField] private GameLevelInspector _gameLevel;
    [SerializeField] private SoundManager _audioManager;
    [SerializeField] private GameOverView _gameOverView;

    private ScreenInfo _screen;

    public ISpawnComplit SpawnManager => _spawnBoxManager;
    public ILevelSystem GameLevel => _gameLevel;

    public IScreenInfoSystem ScreenSystem => _screen;
    public IInitializationSystem Container => _container;   
    public IInitializationSystem Audio => _audioManager;
    public IInitializationSystem GameOverSystem => _gameOverView;

    public IInputSystem InputSystem => _inputKeybordSystem;
    public IInputSystem InputButtonSystem => _gameButtonsController;

    public IStatusGameSystem GameStatusSystem => _gameStatusController;


    private void Start()
    {
        Instance = this;

        _screen = new ScreenInfo(Camera.main);
        _gameStatusController = new GameStatusController();        

        GameLevel.Initialization();
        SpawnManager.Initialization();
        Container.Initialization();
        Audio.Initialization();
        GameOverSystem.Initialization();
    }
}