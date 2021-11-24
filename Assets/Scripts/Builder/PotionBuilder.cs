using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionBuilder
{

    private string _namePotion;
    private int _amountOfHeal;
    private int _costCoins;

    public PotionBuilder Name(string name)
    {
        _namePotion = name;
        return this;
    }

    public PotionBuilder HealAmount(int amountHeal)
    {
        _amountOfHeal = amountHeal;
        return this;
    }

    public PotionBuilder CostCoins(int cost)
    {
        _costCoins = cost;
        return this;
    }


    public Potions Build(Potions potion)
    {
        potion.Config(_namePotion, _amountOfHeal, _costCoins);
        return potion;
    }

}

