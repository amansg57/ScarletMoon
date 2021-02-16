using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Parent class for general unit functionality including stats and damage calculations
[Serializable]
public class Unit : MonoBehaviour
{
    [SerializeField]
    protected int _strength, _dexterity, _intelligence;
    [SerializeField]
    protected int _maxHealth, _health, _physAtk, _magAtk, _speed, _armor, _magDef, _concentration;
    [SerializeField]
    protected float _critMult, _critRate;
    [SerializeField]
    private GameEvent onUnitDeath;
    private Element augmentElement;
    private int augmentTurnCount;
    [SerializeField]
    private float _timeToAct;
    private System.Random rand = new System.Random();

    // Properties
    public bool IsAlive => _health > 0;
    public int Health => _health;
    public int MaxHealth => _maxHealth;
    public int PhysAtk => _physAtk;
    public int MagAtk => _magAtk;
    public float CritRate => _critRate;
    public float CritMult => _critMult;
    public float TimeToAct
    {
        get => _timeToAct;
        set
        {
            if (_health > 0)
            {
                _timeToAct = value;
            }
        }
    }

    // Methods
    public virtual void TakeTurn() {}

    public void TakePhysDamage(float potency, float enemyStatMod, float enemyCritRate, float enemyCritMult)
    {
        float damageReduction = (float)(_armor / (float)(_armor + 50));
        TakeDamage(potency, enemyStatMod, enemyCritRate, enemyCritMult, damageReduction);
    }
    
    public void TakeMagDamage(float potency, float enemyStatMod, float enemyCritRate, float enemyCritMult)
    {
        float damageReduction = (float)(_magDef / (float)(_magDef + 50));
        TakeDamage(potency, enemyStatMod, enemyCritRate, enemyCritMult, damageReduction);
    }

    public void TakeHybridDamage(float potency, float enemyStatMod, float enemyCritRate, float enemyCritMult)
    {
        // Calculate using both Def and MagDef
    }

    public void TakeDamage(float potency, float enemyStatMod, float enemyCritRate, float enemyCritMult, float damageReduction)
    {
        float damage = potency * enemyStatMod;
        
        if (rand.Next(100) < enemyCritRate)
        {
            damage *= enemyCritMult;
        }

        damage *= (float)(1 - damageReduction);
        
        int roundedDamage = (int)Math.Round(damage, 0);
        _health -= roundedDamage;
        DisplayDamage(roundedDamage);

        if (_health <= 0) {OnDeath();}
    }

    public void AugmentElement(Element e, int duration)
    {
        augmentElement = e;
        augmentTurnCount = duration;
    }

    private void DisplayDamage(int damage)
    {
        Debug.Log("Damage: " + damage);
    }

    private void OnDeath()
    {
        onUnitDeath.Raise();
    }

    public virtual void OnBattleEnd()
    {

    }
}
