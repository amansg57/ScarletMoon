using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillListButton : MonoBehaviour
{
    [SerializeField]
    private Text buttonText;
    private PlayerSkill skill;

    public void SetSkill(PlayerSkill s)
    {
        skill = s;
        buttonText.text = skill.name;
    }

    public void OnClick()
    {
        skill.OnMenuButtonClick();
    }
}
