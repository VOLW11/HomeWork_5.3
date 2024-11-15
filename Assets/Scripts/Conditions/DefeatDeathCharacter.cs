using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DefeatDeathCharacter : IConditions
{
    public event Action<string> EndGame;
    private Character _character;

    private string _defeat = "Проигрыш! Вас убили";

    public DefeatDeathCharacter(Character character)
    {
        _character = character;
        _character.DeathCharacter += Death;
    }

    private void Death(Character character)
    {
        GameObject.Destroy(character.gameObject);
        _character.DeathCharacter -= Death;

        EndGame?.Invoke(_defeat);
    }
}
