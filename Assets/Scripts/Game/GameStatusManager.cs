
using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameStatusManager : MonoBehaviour, IStatusGameSystem
{
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _gameButtonPanel;

<<<<<<< HEAD
    private void Start()
    {
        _gameButtonPanel.SetActive(true);
    }
=======
    public event Action GameOver;
    public event Action Start;
    
    private float _deltaTimeGame = 1;
>>>>>>> Refactoring

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
        Time.timeScale = 0;
        
        GameOver?.Invoke();
        
        ActivateObject(_gameOverPanel);
        DeactivateObject(_gameButtonPanel);
    }

    public void StartGame()
    {
<<<<<<< HEAD
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");
=======
        DeactivateObject(_gameOverPanel);
        ActivateObject(_gameButtonPanel);
>>>>>>> Refactoring
    }

    public void SettingBtn()
    {
        SceneManager.LoadScene("SettingScene");
    }

<<<<<<< HEAD
    public void QuitGame()
    {
        Application.Quit();
=======
    public void OnPause()
    {
        Time.timeScale = 0;
    }

    public void OnPlay()
    {
        Time.timeScale = 1;
>>>>>>> Refactoring
    }
}