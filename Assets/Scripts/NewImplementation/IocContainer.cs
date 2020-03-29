using UnityEngine;

public class IocContainer : MonoBehaviour
{
    public static IocContainer Instance { get; private set; }

    [SerializeField] private SpawnBox _spawnBoxManager;
    [SerializeField] private ScreenInfo _screen;
    [SerializeField] private SpawnPlayer _player;
    [SerializeField] private SpawnFloor _floor;
    [SerializeField] private SpawnContainer _container;
    [SerializeField] private InputKeybordSystem _inputKeybordSystem;
    [SerializeField] private GameButtonsController _gameButtonsController;

    public IContainerSystem SpawnManager => _spawnBoxManager;
    public IContainerSystem Screen => _screen;
    public IContainerSystem Player => _player;
    public IContainerSystem Floor => _floor;
    public IContainerSystem Container => _container;
    public IInputSystem InputSystem => _inputKeybordSystem;
    public IInputSystem InputButtonSystem => _gameButtonsController;

    private void Start()
    {
        Instance = this;

        Screen.Init();
        SpawnManager.Init();
        Player.Init();
        Floor.Init();
        Container.Init();
    }
}