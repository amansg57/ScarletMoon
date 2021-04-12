using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Augment
{
    private Element element;
    private int turnsRemaining;
    private float potency;
    private float statMod;
    private float critRate;
    private float critMult;

    public int TurnsRemaining {
        get => turnsRemaining;
        set => turnsRemaining = value;
    }

    public Augment(Element e, int t, float p, float s, float cr, float cm)
    {
        element = e;
        turnsRemaining = t;
        potency = p;
        statMod = s;
        critRate = cr;
        critMult = cm;
    }

    public void DamageUnit(Unit target)
    {
        target.TakeMagDamage(potency, statMod, critRate, critMult, element);
    }
    
}
