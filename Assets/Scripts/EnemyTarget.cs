using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTarget : UnitTarget
{
    public override void AddToTargetSystem()
    {
        targetSystem.AddEnemyTarget(this);
    }
}
