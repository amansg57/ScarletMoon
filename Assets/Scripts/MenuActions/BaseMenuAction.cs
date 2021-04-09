using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMenuAction : MenuAction
{
    protected MenuActionSpawner currentSpawner;
    
    public MenuActionSpawner CurrentSpawner
    {
        set => currentSpawner = value;
    }
}
