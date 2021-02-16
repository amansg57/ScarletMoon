using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles enabling and disabling UnitTargets as well as sending Skill invokes through to Units
[CreateAssetMenu(fileName = "TargetSystem", menuName = "Scarlet Moon/TargetSystem", order = 0)]
public class TargetSystem : ScriptableObject
{
    private List<PlayerTarget> playerTargets = new List<PlayerTarget>();
    private List<EnemyTarget> enemyTargets = new List<EnemyTarget>();

    private PlayerSkill skill;

    public void StartTargetting(PlayerSkill s)
    {
        skill = s;

        if (skill.CastOnEnemy)
        {
            foreach (EnemyTarget et in enemyTargets)
            {
                et.EnableTarget();
            }
        }
        else
        {

        }
    }

    public void SendTarget(Unit unit)
    {
        List<Unit> targets = new List<Unit>();

        if (skill.CastOnAll)
        {
            if (unit.GetType() == typeof(EnemyUnit))
            {
                foreach (EnemyTarget et in enemyTargets)
                {
                    targets.Add(et.UnitParent);
                }
            }
            else
            {
                foreach (PlayerTarget pt in playerTargets)
                {
                    targets.Add(pt.UnitParent);
                }
            }
        }
        else
        {
            targets.Add(unit);
        }
        
        skill.SetTargets(targets);
        EndTargetting();
        skill.Invoke();
    }

    public void AddPlayerTarget(PlayerTarget pt)
    {
        playerTargets.Add(pt);
    }

    public void AddEnemyTarget(EnemyTarget et)
    {
        enemyTargets.Add(et);
    }

    public void RandomTarget(Skill s)
    {
        List<Unit> targets = new List<Unit>();

        if (s.CastOnEnemy)
        {
            if (s.CastOnAll)
            {
                foreach (EnemyTarget et in enemyTargets)
                {
                    targets.Add(et.UnitParent);
                }
            }
            else
            {
                int index = Random.Range(0, enemyTargets.Count);
                targets.Add(enemyTargets[index].UnitParent);
            }
        }
        else
        {
            if (s.CastOnAll)
            {
                foreach (PlayerTarget pt in playerTargets)
                {
                    targets.Add(pt.UnitParent);
                }
            }
            else
            {
                int index = Random.Range(0, playerTargets.Count);
                targets.Add(playerTargets[index].UnitParent);
            }
        }
        s.SetTargets(targets);
        s.Invoke();
    }

    private void OnEnable()
    {
        playerTargets.Clear();
        enemyTargets.Clear();
    }

    private void EndTargetting()
    {
        foreach (EnemyTarget et in enemyTargets)
        {
            et.DisableTarget();
        }

        foreach (PlayerTarget pt in playerTargets)
        {
            pt.DisableTarget();
        }
    }
}
