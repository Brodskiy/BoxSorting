using UnityEngine;


public class IocContainer : MonoBehaviour
{
    public static IocContainer Instance { get; private set; }

    [SerializeField] private SpawnBox _spawnBoxManager;
    [SerializeField] private SpawnPlayer _player;
    [SerializeField] private SpawnFloor _floor;
    [SerializeField] private SpawnContainer _container;
    [SerializeField] private InputKeybordSystem _inputKeybordSystem;
    [SerializeField] private GameButtonsController _gameButtonsController;
    [SerializeField] private GameStatusController _gameStatusController;
    [SerializeField] private GameLevelInspector _gameLevelInspector;
    [SerializeField] private AudioManager _audioManager;

    private ScreenInfo _screen;

    public ISpawnComplit SpawnManager => _spawnBoxManager;

    public IInitializationSystem Player => _player;
    public IScreenInfoSystem ScreenSystem => _screen;
    public IInitializationSystem Floor => _floor;
    public IInitializationSystem Container => _container;   
    public IInitializationSystem Audio => _audioManager;
    public IInitializationSystem GameLevel => _gameLevelInspector;

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
        Player.Initialization();
        Floor.Initialization();
        Container.Initialization();
        Audio.Initialization();
    }
}