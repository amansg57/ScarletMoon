using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Parent class for any actions to be invoked by the player via menu
public class MenuAction : ScriptableObject
{
    public virtual void Invoke()
    {

    }
}
