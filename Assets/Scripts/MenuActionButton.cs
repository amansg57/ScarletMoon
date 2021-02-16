using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuActionButton : MonoBehaviour
{
    [SerializeField]
    private Text buttonText;
    private MenuAction _menuAction;

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
        _menuAction.Invoke();
    }
}
