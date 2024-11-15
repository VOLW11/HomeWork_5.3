using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, IDamageable
{
    public event Action<Character> DeathCharacter;

    [SerializeField] private float _speed;
    [SerializeField] private CharacterController _characterController;

    private Mover _mover;
    private Rotator _rotator;
    private Health _health;
    private float _deadZone = 0.05f;

    private Vector3 _input;

    public void Initialize(Health health)
    {
        _mover = new Mover(_characterController, _speed);
        _rotator = new Rotator(transform);
        _health = health;
        _health.Current.Changed += OnHealthChanged;
    }

    private void Update()
    {
        _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }

    private void FixedUpdate()
    {
        if (_input.magnitude > _deadZone)
        {
            _mover.MoveTo(_input);
            _rotator.ForceRotateTo(_input);
        }
    }

    private void OnDestroy()
    {
        _health.Current.Changed -= OnHealthChanged;
    }

    public void TakeDamage(int damage) => _health.Reduce(damage);

    private void OnHealthChanged(int currentHealth)
    {
        if (currentHealth <= 0)
        {
            DeathCharacter?.Invoke(this);
        }
    }
}
