using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallPotion : Potions, IPotions
{
    [SerializeField]
    CoinsManager _coinsManager = null;

    Potions smallPotion;

    private void Start()
    {
        smallPotion = this;
        BuildPotion();
    }

    public Potions BuildPotion()
    {
        smallPotion = new PotionBuilder().Name("Small Potion")
                                         .HealAmount(5)
                                         .CostCoins(50)
                                         .Build(this);
        return smallPotion;
    }

    public void BuyPotions()
    {
        int cost = BuildPotion().GetPotionCost();
        int hp = BuildPotion().GetHealAmount();
        if (_coinsManager.GetCoin() >= cost)
            EventManager.Instance.Trigger("OnBuyingPotions", -cost, hp);
    }

}
