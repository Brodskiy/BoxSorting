﻿using UnityEngine;

public class SoundManager : MonoBehaviour, IInitializationSystem
{
    [SerializeField] private AudioSource _thow;
    [SerializeField] private AudioSource _gameOver;
    [SerializeField] private AudioSource _levelDane;
    [SerializeField] private AudioSource _boxCrash;
    [SerializeField] private AudioSource _spawnBox;
    [SerializeField] private GameLiveController _gameLive;

    public void Initialization()
    {
        IocContainer.Instance.InputSystem.OnClicked += ButtonClick;
        IocContainer.Instance.InputButtonSystem.OnClicked += ButtonClick;
        IocContainer.Instance.SpawnBox.Spawned += BoxSpawnComplit;
        IocContainer.Instance.GameStatusSystem.OnGameOver += GameOver;
        IocContainer.Instance.GameLevel.OnLevelComplit += PassedLevel;

        _gameLive.LostLive += LiveLost;
    }

    private void LiveLost()
    {
        _boxCrash.Play();
    }

    private void GameOver()
    {
        _gameOver.Play();
    }

    private void BoxSpawnComplit()
    {
        _spawnBox.Play();
    }

    private void PassedLevel()
    {
        _levelDane.Play();
    }

    private void ButtonClick(EInputState obj)
    {
        if (obj == EInputState.Down)
        {
            _thow.Play();
        }
    }
}