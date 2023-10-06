using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static  class Events 
{
    public static Action OnDamageBoss;
    public static Action OnMoveBoss;
    public static Action OnAttackBoss;
    public static Action OnCollectableChance;
    public static Action<bool> OnGameFinish;
}
