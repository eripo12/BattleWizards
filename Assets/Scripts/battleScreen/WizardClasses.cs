using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WizardType
{
    Fire,
    Air,
    Water,
    Lightning,
    Earth
}

public class Wizard
{
    public WizardType Type { get; private set; }
    public float Health { get; protected set; }
    public float Mana { get; protected set; }
    
    private Dictionary<WizardType, List<WizardType>> typeAdvantages;

    public Wizard(WizardType type)
    {
        this.Type = type;
        this.Health = 100.0f; 
        this.Mana = 50.0f;   
        // Define type advantages based on the description
        typeAdvantages = new Dictionary<WizardType, List<WizardType>>
        {
            { WizardType.Fire, new List<WizardType> { WizardType.Lightning, WizardType.Air } },
            { WizardType.Air, new List<WizardType> { WizardType.Water, WizardType.Lightning } },
            { WizardType.Water, new List<WizardType> { WizardType.Fire, WizardType.Earth } },
            { WizardType.Lightning, new List<WizardType> { WizardType.Water, WizardType.Earth } },
            { WizardType.Earth, new List<WizardType> { WizardType.Air, WizardType.Fire } }
        };
    }

    public bool HasAdvantageOver(Wizard opponent)
    {
        return typeAdvantages[this.Type].Contains(opponent.Type);
    }

    public float GetDamageMultiplier(Wizard opponent)
    {
        return HasAdvantageOver(opponent) ? 2.0f : 1.0f; // Returns 2x damage if has type advantage, otherwise it is 1x
    }

    public void TakeDamage(float damage)
    {
        this.Health -= damage;
        if (this.Health < 0) this.Health = 0; // Makes sure health doesn't go negative
    }

    public void CastSpell(float manaCost)
    {
        this.Mana -= manaCost;
        if (this.Mana < 0) this.Mana = 0; // Makes sure mana doesn't go negative
    }
}

public class Player : Wizard
{
    public string Name { get; private set; }
    
    public Player(string name) : base(WizardType.Fire) 
    {
        this.Name = name;
    }

    public void Heal(float amount)
    {
        this.Health += amount;
        if (this.Health > 100) this.Health = 100; 
    }

    public void RegenerateMana(float amount)
    {
        this.Mana += amount;
        if (this.Mana > 50) this.Mana = 50; 
    }
}

