using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class WinKillEnemies : IConditions
{
    public event Action EndGame;

    private EnemySpawner _enemySpawner;
    private int _enemiesKilled = 0;

    public WinKillEnemies(EnemySpawner enemySpawner)
    { 
        _enemySpawner = enemySpawner;

        _enemySpawner.DeathEnemy += KillsEnemy;
    }

    private void KillsEnemy()
    {
        _enemiesKilled++;
        Debug.Log(_enemiesKilled + ": Убито врагов");
        if (_enemiesKilled >= 5)
            EndGame?.Invoke();
    }

  /*  private void Destroy()
    {
        _enemy.Death -= KillsEnemy;
    
    }*/
}