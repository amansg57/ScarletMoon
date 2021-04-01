using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuActionButton : MonoBehaviour
{
    [SerializeField]
    private Text buttonText;
    private MenuAction _menuAction;

    private void Awake()
    {
        buttonText = GetComponentInChildren<Text>();
    }

    public MenuAction MenuAction
    {
        set {
            _menuAction = value;
            buttonText.text = value.ActionName;
        }
        
    }

    public void OnClick()
    {
        _menuAction.OnMenuButtonClick();
    }
}
