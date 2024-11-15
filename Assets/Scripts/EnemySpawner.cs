using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public event Action DeathEnemy;
    public event Action SpawnEnemy;

    private Enemy _enemyPrefab;
    private List<Transform> _points;
    private List<Enemy> _enemies;
    private int _maxHealth;

    private Coroutine _spawnCoroutine;
    private Queue<Vector3> _spawnPoints;
    private Vector3 _currentTarget;

    private bool _isPaused;

    public void Initialize(Enemy enemyPrefab, List<Transform> points, int maxHealth)
    {
        _enemyPrefab = enemyPrefab;
        _points = points;
        _maxHealth = maxHealth;
        _enemies = new List<Enemy>();
    }

    private void Awake()
    {
        _spawnPoints = new Queue<Vector3>();

        foreach (Transform point in _points)
        {
            _spawnPoints.Enqueue(point.position);
        }

        _spawnCoroutine = StartCoroutine(Spawner());

    }

    public void AddEnemy(Enemy enemy)
    {
        _enemies.Add(enemy);
        SpawnEnemy?.Invoke();
    }

    public void RemoveEnemy(Enemy enemy)
    {
        _enemies.Remove(enemy);
        DeathEnemy?.Invoke();
    }

    private IEnumerator Spawner()
    {
        while (_isPaused == false)
        {
            Health health = new Health(_maxHealth);
            SwitchPoint();
            Enemy enemy = Instantiate(_enemyPrefab, _currentTarget, Quaternion.identity, null);
            enemy.Initialize(health, this);
            AddEnemy(enemy);

            Debug.Log(_enemies.Count);

            yield return new WaitForSeconds(5);
        }

        yield return new WaitForSeconds(5);
    }

    private void SwitchPoint()
    {
        _currentTarget = _spawnPoints.Dequeue();
        _spawnPoints.Enqueue(_currentTarget);
    }
}
