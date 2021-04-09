using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnit : Unit
{
    public TextAsset jsonFile;
    [SerializeField]
    private List<EnemySkill> skillList = new List<EnemySkill>();

    private void Awake()
    {
        initialiseStats();
    }

    private void Start()
    {
        foreach (EnemySkill s in skillList)
        {
            s.User = this;
        }
    }

    // Will be replaced by intelligent Skill selecting for each enemy type
    public override void TakeTurn()
    {
        int index = Random.Range(0, skillList.Count);
        skillList[index].SkillStart();
    }

    private void initialiseStats()
    {
        JsonUtility.FromJsonOverwrite(jsonFile.text, this);
        _health = _maxHealth;
    }
}
