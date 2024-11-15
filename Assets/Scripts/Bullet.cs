using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private Rigidbody _rigidbody;

    private int _damage = 10;

    public void Launch(Vector3 direction)
    {
        _rigidbody.AddForce(direction * _force, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.TakeDamage(_damage);
            Destroy(this.gameObject);
        }

        Destroy(this.gameObject);
    }
}
