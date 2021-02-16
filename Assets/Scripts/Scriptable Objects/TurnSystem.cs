using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

// Handles sorting units by when they can next act, invoking turns and overall game mechanic handling
[CreateAssetMenu(fileName = "TurnSystem", menuName = "Scarlet Moon/TurnSystem", order = 0)]
public class TurnSystem : ScriptableObject
{
    private List<Unit> units = new List<Unit>();

    private void OnEnable()
    {
        units.Clear();
    }

    public void Play()
    {
        List<Unit> sortedUnits = units.OrderBy(o=>o.TimeToAct).ToList();

        float timeUntilNext = sortedUnits.First().TimeToAct;

        foreach (Unit u in units)
        {
            u.TimeToAct -= timeUntilNext;
        }

        sortedUnits.First().TakeTurn();

    }

    public void AddUnit(Unit u)
    {
        units.Add(u);
    }

    public void DeathCheck()
    {
        bool enemyDead = true;
        foreach (Unit u in units)
        {
           if(u.GetType() == typeof(EnemyUnit) && u.IsAlive)
           {
                enemyDead = false;
                break;
           }
        }

        bool playerDead = true;
        foreach (Unit u in units)
        {
            if(u.GetType() == typeof(PlayerUnit) && u.IsAlive)
            {
                playerDead = false;
                break;
            }
        }

        if (enemyDead) {EndBattle(true);}
        else if (playerDead) {EndBattle(false);}
    }

    private void EndBattle(bool playerWin)
    {

    }

}
