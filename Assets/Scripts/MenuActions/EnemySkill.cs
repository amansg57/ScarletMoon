using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkill : Skill
{
    public void SkillStart()
    {
        _targetSystem.RandomTarget(this);
    }

}