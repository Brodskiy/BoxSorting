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
    [SerializeField] private SpawnPackage _spawnBox;
    [SerializeField] private SpawnPackage _spawnHeard;
    [SerializeField] private SpawnPackage _spawnDumbbell;
    [SerializeField] private SaveLoadLives _saveLoadLives;
    [SerializeField] private UnityAdsView _unityAdsView;
    [SerializeField] private AdsController _adsController;
    [SerializeField] private GameLiveController _gameLiveController;

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

    public ISpawnPackage SpawnBox => _spawnBox;
    public ISpawnPackage SpawnHeard => _spawnHeard;
    public ISpawnPackage SpawnDummell => _spawnDumbbell;

    public ILiveLoader LiveLoader => _saveLoadLives;

    public IShowAds UnitiShowAds => _unityAdsView;

    public ILiveContrller LiveContrller => _gameLiveController;

    private void Start()
    {
        Instance = this;

        _screen = new ScreenInfo(Camera.main);
        _gameStatusController = new GameStatusController();

        _saveLoadLives.Initialization();
        _gameLiveController.Initialization();

        _gameLevel.Initialization();        

        _spawnFloor.Initialization();
        _spawnCharacter.Initialization();
        _spawnContainer.Initialization();
        _spawnBox.Initialization();
        _spawnDumbbell.Initialization();
        _spawnHeard.Initialization();

        _container.Initialization();

        _audioManager.Initialization();
        _gameOverView.Initialization();

        _unityAdsView.Initialization();
        _adsController.Initialization();
    }
}