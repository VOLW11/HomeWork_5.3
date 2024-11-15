using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private IConditions _conditionWin;
    private IConditions _conditionDefeat;

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

    private void StopGame(string message)
    {
        Debug.Log(message);
        Time.timeScale = 0f;
    }

    private void OnDestroy()
    {
        _conditionWin.EndGame -= StopGame;
        _conditionDefeat.EndGame -= StopGame;
    }
}
