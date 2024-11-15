using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class WinKillEnemies : IConditions
{
    public event Action<string> EndGame;

    private string _win = "Победа! Убито необходимое число врагов";

    private EnemySpawner _enemySpawner;
    private int _enemiesKilled = 0;
    private int _killsToWin = 5;

    public WinKillEnemies(EnemySpawner enemySpawner)
    {
        _enemySpawner = enemySpawner;
        _enemySpawner.DeathEnemy += KillsEnemy;
    }

    private void KillsEnemy()
    {
        _enemiesKilled++;

        if (_enemiesKilled >= _killsToWin)
        {
            Debug.Log(_enemiesKilled + ": Убито врагов");
            _enemySpawner.DeathEnemy -= KillsEnemy;

            EndGame?.Invoke(_win);
        }
    }
}