using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwitcher : ScriptableObject
{
    [SerializeField]
    private TurnSystem turnSystem;
    [SerializeField]
    private TargetSystem targetSystem;
    private Dictionary<int, GameObject> inBattleUnits = new Dictionary<int, GameObject>();
    private Dictionary<int, GameObject> reserveUnits = new Dictionary<int, GameObject>();
    private int currentID;
    [SerializeField]
    private GameEvent onTurnEnd;

    public void AddUnit(GameObject g, bool isInBattle)
    {
        if (isInBattle) inBattleUnits.Add(g.GetComponent<PlayerUnit>().ID, g);
        else reserveUnits.Add(g.GetComponent<PlayerUnit>().ID, g);
    }

    public void StartSwitcher(MenuActionSpawner m, int id)
    {
        m.DeleteButtons();
        currentID = id;
        List<MenuAction> characterMenuActions = new List<MenuAction>();
        foreach (var unit in reserveUnits)
        {
            CharacterMenuAction c = CreateInstance<CharacterMenuAction>();
            c.ActionName = unit.Value.name;
            c.CharacterID = unit.Key;
            c.CharacterSwitcher = this;
            characterMenuActions.Add(c);
        }
        m.SpawnButtonList(characterMenuActions);
    }

    public void SwitchCharacter(int inID)
    {
        reserveUnits.Add(currentID, inBattleUnits[currentID]);
        inBattleUnits.Add(inID, reserveUnits[inID]);

        reserveUnits.Remove(inID);
        inBattleUnits.Remove(currentID);

        turnSystem.RemoveUnit(currentID);
        turnSystem.AddUnit(inBattleUnits[inID].GetComponent<PlayerUnit>());

        targetSystem.ChangeInBattleTargets(currentID, inID);

        Vector3 tempPos = reserveUnits[currentID].transform.position;
        reserveUnits[currentID].transform.position = inBattleUnits[inID].transform.position;
        inBattleUnits[inID].transform.position = tempPos;

        reserveUnits[currentID].GetComponent<PlayerUnit>().OnSwitch();

        onTurnEnd.Raise();
    }
}
