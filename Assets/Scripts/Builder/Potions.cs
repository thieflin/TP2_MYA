using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potions : MonoBehaviour
{

    private string _namePotion;
    private int _amountOfHeal;
    private int _costCoins;


    public void Config(string name, int amount, int cost)
    {
        _namePotion = name;
        _amountOfHeal = amount;
        _costCoins = cost;
    }

    public string GetName()
    {
        return _namePotion;
    }

    public int GetHealAmount()
    {
        return _amountOfHeal;
    }

    public int GetPotionCost()
    {
        return _costCoins;
    }

}
