using UnityEngine;

public class GameOverView : MonoBehaviour, IInitializationSystem
{
    [SerializeField] private GameObject _gameOverPanel;

    public void Initialization()
    {
        IocContainer.Instance.GameStatusSystem.OnGameOver += GameOver;
    }

    private void GameOver()
    {
        _gameOverPanel.SetActive(true);
    }
}