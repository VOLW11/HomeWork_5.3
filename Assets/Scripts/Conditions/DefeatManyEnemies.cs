using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefeatManyEnemies : IConditions
{
    public event Action EndGame;

    private EnemySpawner _enemySpawner;
    private int _enemiesSpawn;

    public DefeatManyEnemies(EnemySpawner enemySpawner)
    {
        _enemySpawner = enemySpawner;

        _enemySpawner.SpawnEnemy += SpawnEnemy;
    }

    private void SpawnEnemy()
    {
        _enemiesSpawn++;
        Debug.Log(_enemiesSpawn + ": Всего врагов");
        if (_enemiesSpawn >= 3)
            EndGame?.Invoke();
    }
}
