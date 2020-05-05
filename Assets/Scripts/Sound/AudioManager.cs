using UnityEngine;

public class AudioManager : MonoBehaviour, IInitializationSystem
{
    [SerializeField] private AudioSource _thow;
    [SerializeField] private AudioSource _gameOver;
    [SerializeField] private AudioSource _levelDane;
    [SerializeField] private AudioSource _boxCrash;
    [SerializeField] private AudioSource _spawnBox;

    [SerializeField] private GameLevelInspector _gameLevelInspector;
    [SerializeField] private GameLiveInspector _gameLiveInspector;
    public void Initialization()
    {
        IocContainer.Instance.InputSystem.OnClicked += Input_OnClicked;

        IocContainer.Instance.InputButtonSystem.OnClicked += Input_OnClicked;

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

    private void Input_OnClicked(EInputState obj)
    {
        if (obj == EInputState.Down)
        {
            _thow.Play();
        }
    }
}