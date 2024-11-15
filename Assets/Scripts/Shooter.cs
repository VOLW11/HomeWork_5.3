using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _shootPoint;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Bullet bullet = Instantiate(_bulletPrefab, _shootPoint.position, transform.rotation, null);
            bullet.Launch(transform.forward);
        }
    }
}
