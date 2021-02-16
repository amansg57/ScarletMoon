using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillListSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject skillButtonPrefab;

    public void SpawnButtonList(List<PlayerSkill> sList)
    {
        for (int i = 0; i < sList.Count; i++)
        {
            SpawnButton(sList[i]);
        }
    }

    public void SpawnButton(PlayerSkill s)
    {
        GameObject button = Instantiate(skillButtonPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        button.transform.SetParent(transform);
        button.GetComponent<SkillListButton>().SetSkill(s);
    }

    public void DeleteButtons()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}
