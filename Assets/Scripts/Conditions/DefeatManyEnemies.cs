using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefeatManyEnemies : IConditions
{
    public event Action<string> EndGame;

    private string _defeat = "Проигрыш! Враг захватил арену";

    private EnemySpawner _enemySpawner;
    private int _maxEnemy = 5;

    public DefeatManyEnemies(EnemySpawner enemySpawner)
    {
        _enemySpawner = enemySpawner;
        _enemySpawner.SpawnEnemy += SpawnEnemy;
    }

    private void SpawnEnemy(List<Enemy> enemiess)
    {
        if (enemiess.Count >= _maxEnemy)
        {
            Debug.Log(enemiess.Count + ": Всего врагов");
            EndGame?.Invoke(_defeat);

            _enemySpawner.SpawnEnemy -= SpawnEnemy;
        }
    }
}
