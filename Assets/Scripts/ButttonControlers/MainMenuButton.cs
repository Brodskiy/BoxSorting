using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void SettingGame()
    {
        //TODO setting
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
