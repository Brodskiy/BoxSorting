using System;
using UnityEngine;

public class SpawnTimer : MonoBehaviour
{
    public event Action TimeToCreate;

    private bool _isTimerStarted;
    private float _spawnTime;
    private float _timer;

    private void Update()
    {
        TimeController();        
    }

    private void TimeController()
    {
        if (_isTimerStarted)
        {
            _timer += Time.deltaTime;
            TimerCheck();
        }
    }

    private void TimerCheck()
    {
        if (_timer >= _spawnTime)
        {
            _timer = 0;
            TimeToCreate?.Invoke();
        }
    }

    public void StartTimer(float spawnTime)
    {
        if (IocContainer.Instance.GameStatusSystem.IsCanSpawn)
        {
            _spawnTime = spawnTime;
            _isTimerStarted = true;
        }            
    }

    public void StopTimer()
    {
        _isTimerStarted = false;
    }     
}