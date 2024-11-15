using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTime : MonoBehaviour, IConditions
{
    public event Action<string> EndGame;

    private string _win = "Победа! Вы продержались необходимое время";
    private bool _isTimerOn;
    private float _time = 0;
    private float _timeRound = 20;

    public void Initialize(bool isTimerOn)
    {
        _isTimerOn = isTimerOn;
    }

    private void Update()
    {
        if (_isTimerOn == false)
            return;

        Timer();
    }

    private void Timer()
    {
        _time += Time.deltaTime;

        if (_time >= _timeRound)
        {
            _isTimerOn = false;
            Debug.Log(_time + " Time");

            EndGame?.Invoke(_win);
        }
    }
}
