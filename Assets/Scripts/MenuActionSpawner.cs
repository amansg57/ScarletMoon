using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuActionSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject menuButtonPrefab;
    
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

    public void DeleteButtons()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}
