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
    [SerializeField] private GameStatusView _gameStatusManager;
    [SerializeField] private GameLevelInspector _gameLevelInspector;
    [SerializeField] private AudioManager _audioManager;

    private ScreenInfo _screen;

    public ISpawnComplit SpawnManager => _spawnBoxManager;

    public IContainerSystem Player => _player;
    public IScreenInfoSystem ScreenSystem => _screen;
    public IContainerSystem Floor => _floor;
    public IContainerSystem Container => _container;   
    public IContainerSystem Audio => _audioManager;
    public IContainerSystem GameLevel => _gameLevelInspector;


    public IInputSystem InputSystem => _inputKeybordSystem;
    public IInputSystem InputButtonSystem => _gameButtonsController;

    public IStatusGameSystem GameStatusSystem => _gameStatusManager;


    private void Start()
    {
        Instance = this;

        _screen = new ScreenInfo(Camera.main);

        GameLevel.Init();
        SpawnManager.Init();
        Player.Init();
        Floor.Init();
        Container.Init();
        Audio.Init();
    }
}