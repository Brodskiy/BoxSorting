using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameStatusManager : MonoBehaviour, IStatusGameSystem
{
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _gameButtonPanel;

    public event Action GameOver;
    public event Action Start;
    
    private void ActivateObject(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }

    private void DeactivateObject(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }

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
        if(SceneManager.GetActiveScene().name == "GameScene")
        {
            DeactivateObject(_gameOverPanel);
            ActivateObject(_gameButtonPanel);
        }
        else
        {
            SceneManager.LoadScene("GameScene");
        }
    }

    public void SettingBtn()
    {
        //SceneManager.LoadScene("SettingScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void OnPause()
    {
        Time.timeScale = 0;
    }

    public void OnPlay()
    {
        Time.timeScale = 1;
    }
}