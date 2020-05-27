using UnityEngine;
using UnityEngine.UI;

public class PauseButtonsView : MonoBehaviour
{
    [SerializeField] private GameObject _gameButtonsPanel;
    [SerializeField] private GameObject _pausePanel;

    [SerializeField] private Button _btnPause;
    [SerializeField] private Button _btnContinue;
    [SerializeField] private Button _btnRestart;
    [SerializeField] private Button _btnLevel;


    private void Start()
    {
        _btnPause.onClick.AddListener(PauseGame);
        _btnContinue.onClick.AddListener(ContinueGame);
        _btnLevel.onClick.AddListener(OnPlay);
        _btnRestart.onClick.AddListener(OnPlay);
    }

    private void OnPlay()
    {
        IocContainer.Instance.GameStatusSystem.Play();
    }

    public void PauseGame()
    {
        IocContainer.Instance.GameStatusSystem.Pause();        
        ChangeView(false);
    }

    public void ContinueGame()
    {
        IocContainer.Instance.GameStatusSystem.Play();
        ChangeView(true);
    }

    private void ChangeView(bool status)
    {
        _gameButtonsPanel.SetActive(status);
        _pausePanel.SetActive(!status);
    }
}