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
        IocContainer.Instance.InputSystem.OnClicked += _input_OnClicked;
        IocContainer.Instance.InputSystem.OnClickedOff += _input_OnClickedOff;

        IocContainer.Instance.InputButtonSystem.OnClicked += _input_OnClicked;
        IocContainer.Instance.InputButtonSystem.OnClickedOff += _input_OnClickedOff;
        
        IocContainer.Instance.SpawnManager.SpawnComplit += _spawnBoxEvetn_SpawnComplit;

        _gameLevelInspector.LevelPassed += _gameLevelInspector_LevelPassed;
        _gameLiveInspector.GameOver += _gameLiveInspector_GameOver;
        _gameLiveInspector.LiveLost += _gameLiveInspector_LiveLost;
    }

    private void _gameLiveInspector_LiveLost()
    {
        _boxCrash.Play();
    }

    private void _gameLiveInspector_GameOver()
    {
        _gameOver.Play();
    }

    private void _spawnBoxEvetn_SpawnComplit()
    {
        _spawnBox.Play();
    }

    private void _gameLevelInspector_LevelPassed(LevelModelBase obj)
    {
        _levelDane.Play();
    }

    private void _input_OnClickedOff()
    {
        _stay.Play();
    }

    private void _input_OnClicked(EInputState obj)
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
