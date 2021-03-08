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
            Debug.Log(value);
            _menuAction = value;
            buttonText.text = value.name;
        }
        
    }

    public void OnClick()
    {
        Debug.Log(_menuAction);
        _menuAction.OnMenuButtonClick();
    }
}
