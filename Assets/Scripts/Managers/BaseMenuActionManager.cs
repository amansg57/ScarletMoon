using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMenuActionManager : ScriptableObject
{
    public List<BaseMenuAction> baseMenuActions = new List<BaseMenuAction>();

    public void SetCurrentSpawner(MenuActionSpawner menuActionSpawner)
    {
        foreach (BaseMenuAction m in baseMenuActions)
        {
            m.CurrentSpawner = menuActionSpawner;
        }
    }
}
