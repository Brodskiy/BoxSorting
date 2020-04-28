using System;
using UnityEngine;

public class GameStatusView : MonoBehaviour, IStatusGameSystem
{
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _gameButtonPanel;
    
    public event Action GameOver;
    public event Action GameStart;
    
    public void OnGameOver()
    {
        OnPause();

        GameOver?.Invoke();

        ActivateObject(_gameOverPanel);
        DeactivateObject(_gameButtonPanel);
    }

    public void StartGame()
    {
        OnPlay();
    }

    public void OnPause()
    {
        Time.timeScale = 0;
    }

    public void OnPlay()
    {
        Time.timeScale = 1;
    }

    private void ActivateObject(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }

    private void DeactivateObject(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }
}