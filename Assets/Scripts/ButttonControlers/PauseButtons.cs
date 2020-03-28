using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButtons : MonoBehaviour
{
    [SerializeField] private GameObject _gameButtonsPanel;
    [SerializeField] private GameObject _pausePanel;

    public void PauseGame()
    {
        Time.timeScale = 0;
        _gameButtonsPanel.SetActive(false);
        _pausePanel.SetActive(true);
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
        _gameButtonsPanel.SetActive(true);
        _pausePanel.SetActive(false);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");
    }

    public void OpenStartMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
