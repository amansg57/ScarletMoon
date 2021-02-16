using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeTestScript : MonoBehaviour
{
    public Unit unit;
    public Text timeText;

    void Start()
    {
        unit = gameObject.GetComponentInParent<Unit>();
    }

    void Update()
    {
        timeText.text = string.Format("{0:N1}", unit.TimeToAct);
    }
}
