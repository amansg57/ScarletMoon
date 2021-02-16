using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBarScript : MonoBehaviour
{
    private float maxHP;
    public Unit unitScript;
    public Image bar;
    public TMP_Text healthText;
    private float healthPercent;
    private float currentHPBarPercent;
    private float smoothVelocity;
    private float smoothTime = 0.3f;

    private void Start()
    {
        maxHP = unitScript.MaxHealth;
        healthText = GetComponentInChildren<TMP_Text>();
    }

    // If HP changes, bar will smoothly fill to the correct position
    private void Update()
    {
        healthPercent = unitScript.Health / maxHP;
        currentHPBarPercent = Mathf.SmoothDamp(currentHPBarPercent, healthPercent, ref smoothVelocity, smoothTime);
        bar.fillAmount = currentHPBarPercent;
        healthText.text = unitScript.Health + " / " + maxHP;
    }
}
