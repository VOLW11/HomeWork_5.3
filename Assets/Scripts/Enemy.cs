using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private float _speed;
    [SerializeField] private CharacterController _characterController;

    private Mover _mover;
    private Rotator _rotator;
    private int _damage = 10;
    private float _timeChangePoint = 1f;
    private float _deadZone = 0.05f;

    private Vector3 _randomPoint;

    private float _time;
    private Health _health;
    private EnemySpawner _enemySpawner;

    public void Initialize(Health health, EnemySpawner enemySpawner)
    {
        _mover = new Mover(_characterController, _speed);
        _rotator = new Rotator(transform);
        _health = health;
        _health.Current.Changed += OnHealthChanged;
        _enemySpawner = enemySpawner;
    }

    private void Update()
    {
        _time += Time.deltaTime;

        if (_time >= _timeChangePoint)
        {
            _randomPoint = new Vector3(UnityEngine.Random.Range(-180, 180), 0, UnityEngine.Random.Range(-180, 180));
            _time = 0;
        }
    }

    private void FixedUpdate()
    {
        if (_randomPoint.magnitude > _deadZone)
        {
            _mover.MoveTo(_randomPoint);
            _rotator.ForceRotateTo(_randomPoint);
        }
    }

    private void OnDestroy()
    {
        _health.Current.Changed -= OnHealthChanged;
    }

    private void OnTriggerEnter(Collider other)
    {
        Character character = other.GetComponent<Character>();

        if (character != null)
        {
            character.TakeDamage(_damage);
        }
    }

    public void TakeDamage(int damage) => _health.Reduce(damage);

    private void OnHealthChanged(int currentHealth)
    {
        if (currentHealth <= 0)
        {
           _enemySpawner.RemoveEnemy(this);
            Destroy(gameObject);
        }
    }
}
