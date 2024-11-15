using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private IConditions _conditionWin;
    private IConditions _conditionDefeat;

    private Character _character;

    public void Initialize(Character character)
    {
        _character = character;
    }

   public void InitializeWin(IConditions conditionWin)
    {
        _conditionWin = conditionWin;
        _conditionWin.EndGame += StopGame;
    }

    public void InitializeDefeat(IConditions conditionDefeat)
    {
        _conditionDefeat = conditionDefeat;
        _conditionDefeat.EndGame += StopGame;
    }

    private void Awake()
    {
       // _conditionWin.WinGame += StopGame;
    }

    private void StopGame()
    {
        Debug.Log("Получилось еба");
    }
}
