using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseButtonsView : MonoBehaviour
{
    [SerializeField] private GameObject _gameButtonsPanel;
    [SerializeField] private GameObject _pausePanel;

    [SerializeField] private Button _btnPause;
    [SerializeField] private Button _btnContinue;
    [SerializeField] private Button _btnRestart;
    [SerializeField] private Button _btnMainMenu;

    private void Start()
    {
        _btnPause.onClick.AddListener(PauseGame);
        _btnContinue.onClick.AddListener(ContinueGame);
        _btnRestart.onClick.AddListener(RestartGame);
        _btnMainMenu.onClick.AddListener(OpenStartMenu);
    }   

    public void PauseGame()
    {
        IocContainer.Instance.GameStatusSystem.OnPause();
        
        ChangeView(false);
    }

    public void ContinueGame()
    {
        IocContainer.Instance.GameStatusSystem.OnPlay();
        
        ChangeView(true);
    }

    public void RestartGame()
    {
        IocContainer.Instance.GameStatusSystem.OnPlay();
        
        SceneManager.LoadScene("GameScene");
    }

    public void OpenStartMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    private void ChangeView(bool status)
    {
        _gameButtonsPanel.SetActive(status);
        _pausePanel.SetActive(!status);
    }
}
