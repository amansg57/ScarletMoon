using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTarget : UnitTarget
{
    public override void AddToTargetSystem()
    {
        targetSystem.AddPlayerTarget(this);
    }
}
