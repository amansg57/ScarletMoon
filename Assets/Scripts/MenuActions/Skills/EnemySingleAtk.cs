using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemySingleAtk", menuName = "Scarlet Moon/Enemy Skills/EnemySingleAtk", order = 0)]
public class EnemySingleAtk : EnemySkill
{
    private float potency;

    private void OnEnable() 
    {
        _castOnAll = false;
        _castOnEnemy = false;
        potency = 5;
        timeSpent = 3;
    }

    public override void Invoke()
    {
        targets[0].TakePhysDamage(potency, _user.PhysAtk, _user.CritRate, _user.CritMult, element);
        FinishSkill();
    }
}
