using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MenuAction
{
    public List<Unit> targets = new List<Unit>();
    protected Unit _user;
    protected bool _castOnEnemy, _castOnAll;
    protected int timeSpent;
    protected Element element;
    protected static TargetSystem _targetSystem;
    protected static GameEvent _onTurnEnd;
    protected bool augmentable;

    protected virtual void FinishSkill()
    {
        UpdateTime();
        _onTurnEnd.Raise();
    }

    public bool CastOnEnemy => _castOnEnemy;

    public bool CastOnAll => _castOnAll;

    public Unit User
    {
        set => _user = value;
    }

    public TargetSystem TargetSystem
    {
        set => _targetSystem = value;
    }

    public GameEvent OnTurnEndEvent
    {
        set => _onTurnEnd = value;
    }

    public void SetTargets(List<Unit> t)
    {
        targets.Clear();
        
        foreach (Unit target in t)
        {
            targets.Add(target);
        }
    }

    protected void UpdateTime()
    {
        _user.TimeToAct = timeSpent;
        Debug.Log(this.name + ": " + timeSpent);
    }

    public virtual void Invoke()
    {
        AugmentDamage();
    }
    
    protected void AugmentDamage()
    {
        if (_user.Augment != null)
        {
            foreach (Unit t in targets)
            {
                _user.Augment.DamageUnit(t);
            }
        }
    }

}
