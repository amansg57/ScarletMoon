using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : Skill
{
    protected bool isSpecial;
    protected int meterMod;
    public void SkillClick()
    {
        _targetSystem.StartTargetting(this);
    }

    protected override void FinishSkill()
    {
        PlayerUnit playerUser = (PlayerUnit)_user;
        playerUser.EndTurn();
        if (isSpecial) {playerUser.RemoveMeter(meterMod);}
        else {playerUser.AddMeter(meterMod);}
        base.FinishSkill();
    }

}