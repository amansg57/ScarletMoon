using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BasicSkillsMenuAction", menuName = "Scarlet Moon/Menu Actions/BasicSkillsMenuAction", order = 0)]
public class BasicSkillsMenuAction : BaseMenuAction
{
    public override void OnMenuButtonClick()
    {
        currentSpawner.SpawnBasicSkillButtons();
    }
}
