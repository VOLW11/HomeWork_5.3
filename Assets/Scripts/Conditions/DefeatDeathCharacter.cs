using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DefeatDeathCharacter : IConditions
{
    public event Action EndGame;
    private Character _character;

    public DefeatDeathCharacter(Character character)
    {
        _character = character;

        _character.DeathCharacter += Death;
    }

    private void Death(Character character)
    {
        GameObject.Destroy(character.gameObject);

        EndGame?.Invoke();     
    }
}
