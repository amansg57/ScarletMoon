using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupScript : MonoBehaviour
{
    public TurnSystem turnSystem;
    public TargetSystem targetSystem;
    public CharacterSwitcher characterSwitcher;
    public Skill dummySkill;
    public List<GameObject> inBattleUnits = new List<GameObject>();
    public List<GameObject> reserveUnits = new List<GameObject>();
    public GameEvent onTurnEnd;

    private void Start()
    {
        List<int> inBattleIDs = new List<int>();

        foreach (GameObject g in inBattleUnits)
        {
            Unit unit = g.GetComponent<Unit>();
            turnSystem.AddUnit(unit);
            inBattleIDs.Add(unit.ID);
            characterSwitcher.AddUnit(g, true);
        }

        foreach (GameObject g in reserveUnits)
        {
            characterSwitcher.AddUnit(g, false);
        }

        dummySkill.TargetSystem = targetSystem;
        dummySkill.OnTurnEndEvent = onTurnEnd;
        
        targetSystem.SetInBattleTargets(inBattleIDs);

        StartCoroutine(LateStart(1));
    }

    IEnumerator LateStart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        turnSystem.Play();
    }
}
