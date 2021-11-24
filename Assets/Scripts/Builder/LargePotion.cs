using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargePotion : Potions, IPotions
{
    [SerializeField]
    CoinsManager _coinsManager = null;

    Potions largePotion;

    private void Start()
    {
        largePotion = this;
        BuildPotion();
        
    }

    public Potions BuildPotion()
    {
        largePotion = new PotionBuilder().Name("Medium Potion")
                                         .HealAmount(30)
                                         .CostCoins(150)
                                         .Build(this);
        return largePotion;
    }

    public void BuyPotions()
    {
        int cost = BuildPotion().GetPotionCost();
        int hp = BuildPotion().GetHealAmount();

        if (_coinsManager.GetCoin() >= cost)
            EventManager.Instance.Trigger("OnBuyingPotions", -cost, hp);
    }

}

