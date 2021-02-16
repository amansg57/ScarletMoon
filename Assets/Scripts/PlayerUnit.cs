using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : Unit
{
    public float meter;
    public float meterGainMult;
    [SerializeField]
    private List<PlayerSkill> skills = new List<PlayerSkill>();
    private List<MenuAction> menuActions = new List<MenuAction>();
    private MenuActionSpawner menuActionSpawner;
    public UnitSO unitSO;

    private void Awake()
    {
        _strength = unitSO.Strength;
        _dexterity = unitSO.Dexterity;
        _intelligence = unitSO.Intelligence;
        _maxHealth = unitSO.MaxHealth;
        _health = unitSO.Health;
        _physAtk = unitSO.PhysAtk;
        _magAtk = unitSO.MagAtk;
        _speed = unitSO.Speed;
        _armor = unitSO.Armor;
        _magDef = unitSO.MagDef;
        _critRate = unitSO.CritRate;
        _concentration = unitSO.Concentration;
        _critMult = unitSO.CritMult;
    }

    private void Start()
    {
        menuActionSpawner = gameObject.GetComponentInChildren<MenuActionSpawner>();

        foreach (PlayerSkill s in skills)
        {
            s.User = this;
            menuActions.Add(s);
        }
        
    }

    public override void TakeTurn()
    {
        menuActionSpawner.SpawnButtonList(menuActions);
    }

    public void EndTurn()
    {
        menuActionSpawner.DeleteButtons();
    }

    public void AddMeter(int meterMod)
    {
        meter += meterMod * meterGainMult;
    }

    public void RemoveMeter(int meterMod)
    {
        meter -= meterMod;
    }

    public override void OnBattleEnd()
    {
        unitSO.Health = _health;
        base.OnBattleEnd();
    }
}
