using UnityEngine;

public class AudioManager : MonoBehaviour, IContainerSystem
{
    [SerializeField] private AudioSource _run;
    [SerializeField] private AudioSource _thow;
    [SerializeField] private AudioSource _stay;
    [SerializeField] private AudioSource _gameOver;
    [SerializeField] private AudioSource _levelDane;
    [SerializeField] private AudioSource _boxCrash;
    [SerializeField] private AudioSource _spawnBox;

    [SerializeField] private GameLevelInspector _gameLevelInspector;
    [SerializeField] private GameLiveInspector _gameLiveInspector;
    public void Init()
    {
        IocContainer.Instance.InputSystem.OnClicked += Input_OnClicked;
        IocContainer.Instance.InputSystem.OnClickedOff += Input_OnClickedOff;

        IocContainer.Instance.InputButtonSystem.OnClicked += Input_OnClicked;
        IocContainer.Instance.InputButtonSystem.OnClickedOff += Input_OnClickedOff;
        
        IocContainer.Instance.SpawnManager.SpawnComplit += SpawnBoxEvetn_SpawnComplit;

        _gameLevelInspector.LevelPassed += GameLevelInspector_LevelPassed;
        _gameLiveInspector.GameOver += GameLiveInspector_GameOver;
        _gameLiveInspector.LiveLost += GameLiveInspector_LiveLost;
    }

    private void GameLiveInspector_LiveLost()
    {
        _boxCrash.Play();
    }

    private void GameLiveInspector_GameOver()
    {
        _gameOver.Play();
    }

    private void SpawnBoxEvetn_SpawnComplit()
    {
        _spawnBox.Play();
    }

    private void GameLevelInspector_LevelPassed(LevelModelBase obj)
    {
        _levelDane.Play();
    }

    private void Input_OnClickedOff()
    {
        _stay.Play();
    }

    private void Input_OnClicked(EInputState obj)
    {
        switch (obj)
        {
            case EInputState.Left:
                _run.Play();
                break;
            case EInputState.Right:
                _run.Play();
                break;
            case EInputState.Down:
                _thow.Play();
                break;
        }
    }
}
