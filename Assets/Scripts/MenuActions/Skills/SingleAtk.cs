using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SingleAtk", menuName = "Scarlet Moon/Player Skills/SingleAtk", order = 0)]
public class SingleAtk : PlayerSkill
{
    private float potency;

    private void OnEnable() 
    {
        _castOnAll = false;
        _castOnEnemy = true;
        isSpecial = false;
        potency = 5;
        timeSpent = 5;
        meterMod = 1;
        element = Element.None;
        augmentable = true;
    }

    public override void Invoke()
    {
        targets[0].TakePhysDamage(potency, _user.PhysAtk, _user.CritRate, _user.CritMult, element);
        base.Invoke();
        FinishSkill();
    }
}
