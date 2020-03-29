using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseButtonsView : MonoBehaviour
{
    [SerializeField] private GameObject _gameButtonsPanel;
    [SerializeField] private GameObject _pausePanel;

    [SerializeField] private Button _btnPause;
    [SerializeField] private Button _btnContinue;

    private EventTrigger _btnTriger;


    private void Start()
    {
        _btnPause.onClick.AddListener(PauseGame);
        _btnContinue.onClick.AddListener(RestartGame); // todo: remove on the scene 

        _btnTriger.OnPointerUp();
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
