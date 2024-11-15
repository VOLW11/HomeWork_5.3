using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover
{
    private CharacterController _characterController;

    private float _speed;

    public Mover(CharacterController characterController, float speed)
    {
        _characterController = characterController;
        _speed = speed;
    }

    public void MoveTo(Vector3 direction)
    {
        Vector3 velocity = direction.normalized * _speed;

        _characterController.Move(velocity * Time.deltaTime);
    }
}
