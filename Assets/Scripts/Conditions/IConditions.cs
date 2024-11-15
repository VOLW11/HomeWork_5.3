using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IConditions
{
    event Action<string> EndGame;
}
