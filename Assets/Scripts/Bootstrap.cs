using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private DefeatConditions _defeatConditions;
    [SerializeField] private WinConditions _winConditions;

    [SerializeField] private Character _characterPrefab;
    [SerializeField] private CinemachineVirtualCamera _camera;

    [SerializeField] private int _maxHealth;
    [SerializeField] private Game _game;
    [SerializeField] private WinTime _winTime;

    [SerializeField] Enemy _enemyPrefab;
    [SerializeField] EnemySpawner _enemySpawner;
    [SerializeField] private List<Transform> _points;

    private void Awake()
    {
        Health health = new Health(_maxHealth);

        Character character = Instantiate(_characterPrefab, transform.position, Quaternion.identity, null);
        character.Initialize(health);
        _camera.Follow = character.transform;

        _enemySpawner.Initialize(_enemyPrefab, _points, _maxHealth);

        switch (_defeatConditions)
        {
            case DefeatConditions.ManyEnemies:
                _game.InitializeDefeat(new DefeatManyEnemies(_enemySpawner));
                break;

            case DefeatConditions.PlayerDeath:
                _game.InitializeDefeat(new DefeatDeathCharacter(character));
                break;
        }

        switch (_winConditions)
        {
            case WinConditions.Time:
                _winTime.Initialize(true);
                _game.InitializeWin(_winTime);
                break;

            case WinConditions.killEnemies:
                _game.InitializeWin(new WinKillEnemies(_enemySpawner));
                break;
        }
    }
}
