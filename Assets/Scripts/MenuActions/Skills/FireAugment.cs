using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FireAugment", menuName = "Scarlet Moon/Player Skills/FireAugment", order = 0)]
public class FireAugment : PlayerSkill
{
    private float potency;

    private void OnEnable() 
    {
        _castOnAll = false;
        _castOnEnemy = false;
        isSpecial = false;
        potency = 2;
        timeSpent = 3;
        meterMod = 1;
        element = Element.Fire;
    }

    public override void OnMenuButtonClick()
    {
        Invoke();
    }

    public override void Invoke()
    {
        _user.Augment = new Augment(element, 5, potency, _user.MagAtk, _user.CritRate, _user.CritMult);
        FinishSkill();
    }
}
