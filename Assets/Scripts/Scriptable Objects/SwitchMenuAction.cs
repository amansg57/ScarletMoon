using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SwitchMenuAction", menuName = "Scarlet Moon/Menu Actions/SwitchMenuAction", order = 0)]
public class SwitchMenuAction : BaseMenuAction
{
    [SerializeField]
    private CharacterSwitcher characterSwitcher;
    public override void OnMenuButtonClick()
    {
        characterSwitcher.StartSwitcher(currentSpawner, currentSpawner.ID);
    }
}
