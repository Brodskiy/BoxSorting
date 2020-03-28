using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStatusManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _gameButtonPanel;

    private void ActivateObject(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }

    private void DeactivateObject(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        ActivateObject(_gameOverPanel);
        DeactivateObject(_gameButtonPanel);
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        DeactivateObject(_gameOverPanel);
        ActivateObject(_gameButtonPanel);
    }

    public void SettingBtn()
    {
        SceneManager.LoadScene("SettingScene");
    }
}