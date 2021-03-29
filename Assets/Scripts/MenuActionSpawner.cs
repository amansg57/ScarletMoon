using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class MenuActionSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject menuButtonPrefab;
    [SerializeField]
    private BaseMenuActionManager baseMenuActionManager;
    private PlayerUnit playerUnit;

    private void Start()
    {
        playerUnit = gameObject.GetComponentInParent<PlayerUnit>();
    }
    
    public void SpawnButtonList(List<MenuAction> aList)
    {
        for (int i = 0; i < aList.Count; i++)
        {
            SpawnButton(aList[i]);
        }
    }

    public void SpawnButton(MenuAction a)
    {
        GameObject button = Instantiate(menuButtonPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        button.transform.SetParent(transform);
        button.GetComponent<MenuActionButton>().MenuAction = a;
    }

    public void CreateBaseMenu()
    {
        baseMenuActionManager.SetCurrentSpawner(this);
        SpawnButtonList(baseMenuActionManager.baseMenuActions.Cast<MenuAction>().ToList());
    }

    public void SpawnBasicSkillButtons()
    {
        DeleteButtons();
        List<MenuAction> menuActionList = playerUnit.BasicSkills.Cast<MenuAction>().ToList();
        SpawnButtonList(menuActionList);
    }

    public void SpawnEXSkillButtons()
    {

    }

    public void SpawnItemButtons()
    {

    }

    public void SpawnSwitchButtons()
    {

    }

    public void DeleteButtons()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}
