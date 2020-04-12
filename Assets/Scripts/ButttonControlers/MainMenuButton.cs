using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButton : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private float _speedTransition = 10f;

    private string _loadScene;
    private bool _isLoadScene;

    private void Update()
    {
        if (_isLoadScene)
        {
            TransitionBetweenScenes(_loadScene);
        }
    }

    private void TransitionBetweenScenes(string sceneName)
    {
        _image.enabled = true;
        _image.color = Color.Lerp(_image.color, Color.black, _speedTransition * Time.deltaTime);

        if (_image.color.a >= 0.8f)
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    public void StartGame()
    {
        _loadScene = "GameScene";
        _isLoadScene = true;
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
