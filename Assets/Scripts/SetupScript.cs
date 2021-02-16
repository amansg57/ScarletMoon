using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupScript : MonoBehaviour
{
    public TurnSystem turnSystem;
    public TargetSystem targetSystem;
    public Skill dummySkill;
    public List<Unit> units = new List<Unit>();
    public GameEvent onTurnEnd;

    private void Start()
    {
        foreach (Unit u in units)
        {
            turnSystem.AddUnit(u);
        }

        dummySkill.TargetSystem = targetSystem;
        dummySkill.OnTurnEndEvent = onTurnEnd;

        StartCoroutine(LateStart(1));
        
    }

    IEnumerator LateStart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        turnSystem.Play();
    }
}
