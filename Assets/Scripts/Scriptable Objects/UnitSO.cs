using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Scriptable Object that holds attribute information for a Unit
[CreateAssetMenu(fileName = "UnitSO", menuName = "Scarlet Moon/UnitSO", order = 0)]
public class UnitSO : ScriptableObject
{
    [SerializeField]
    private int _strength, _dexterity, _intelligence;
    [SerializeField]
    private int _maxHealth, _health, _physAtk, _magAtk, _speed, _armor, _magDef, _concentration; // Base stats
    [SerializeField]
    private float _critMult, _critRate;
    public GameObject characterPrefab;
    public TextAsset jsonFile;

    // Gear references
    private string characterName;

    // Redefine these in separate file instead
    private const float healthMod = 10,
                        physAtkMod = 1,
                        speedMod = 1,
                        critRateMod = 0.5f,
                        magAtkMod = 1,
                        concentrationMod = 1;


    public int Strength => _strength;
    public int Dexterity => _dexterity;
    public int Intelligence => _intelligence;

    public int MaxHealth
    {
        get => _maxHealth + (int)(_strength * healthMod);
        set => _maxHealth = value;
    }

    public int Health
    {
        get => _health;
        set => _health = value;
    }

    public int PhysAtk
    {
        get => _physAtk + (int)(_strength * physAtkMod);
    }

    public int MagAtk
    {
        get => _magAtk + (int)(_intelligence * magAtkMod);
    }

    public int Speed
    {
        get => _speed + (int)(_dexterity * speedMod);
    }

    public int Armor
    {
        get => _armor;
    }

    public int MagDef
    {
        get => _magDef;
    }

    public float CritRate
    {
        get => _critRate + (_dexterity * critRateMod);
    }

    public int Concentration
    {
        get => _concentration + (int)(_intelligence * concentrationMod);
    }

    public float CritMult
    {
        get => _critMult;
    }

    public void InitialiseFromJson()
    {
        JsonUtility.FromJsonOverwrite(jsonFile.text, this);
        Health = MaxHealth;
    }

}
