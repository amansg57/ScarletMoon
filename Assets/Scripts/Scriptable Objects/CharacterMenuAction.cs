using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMenuAction : MenuAction
{
    public int CharacterID {get; set;}
    public CharacterSwitcher CharacterSwitcher {get; set;}

    public override void OnMenuButtonClick()
    {
        CharacterSwitcher.SwitchCharacter(CharacterID);
    }
}
