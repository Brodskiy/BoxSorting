using UnityEngine;

public class IocContainer : MonoBehaviour
{
    public static IocContainer Instance { get; private set; }

    [SerializeField] private ContainerController _container;
    [SerializeField] private InputKeybordSystem _inputKeybordSystem;
    [SerializeField] private GameButtonsController _gameButtonsController;
    [SerializeField] private GameStatusController _gameStatusController;
    [SerializeField] private GameLevelInspector _gameLevel;
    [SerializeField] private SoundManager _audioManager;
    [SerializeField] private GameOverView _gameOverView;
    [SerializeField] private SpawnStillObject _spawnFloor;
    [SerializeField] private SpawnStillObject _spawnCharacter;
    [SerializeField] private SpawnContainerSystem _spawnContainer;
    [SerializeField] private SpawnPackage _spawnPackage;

    private ScreenInfo _screen;


    public GameLevelInspector GameLevel => _gameLevel;

    public IScreenInfoSystem ScreenSystem => _screen;
    public IInitializationSystem Container => _container;   
    public IInitializationSystem Audio => _audioManager;
    public IInitializationSystem GameOverSystem => _gameOverView;

    public IInputSystem InputSystem => _inputKeybordSystem;
    public IInputSystem InputButtonSystem => _gameButtonsController;

    public IStatusGameSystem GameStatusSystem => _gameStatusController;

    public SpawnContainerSystem SpawnContainerSystem => _spawnContainer;


    private void Start()
    {
        Instance = this;

        _screen = new ScreenInfo(Camera.main);
        _gameStatusController = new GameStatusController();        

        GameLevel.Initialization();
        

        _spawnFloor.Init();
        _spawnCharacter.Init();
        _spawnContainer.Init();
        _spawnPackage.Inicialization();

        Container.Initialization();

        Audio.Initialization();
        GameOverSystem.Initialization();
    }
}