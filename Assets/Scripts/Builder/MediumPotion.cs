using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumPotion : Potions, IPotions
{
    [SerializeField]
    CoinsManager _coinsManager = null;

    Potions mediumPotion;

    private void Start()
    {
        mediumPotion = this;
        BuildPotion();
    }

    public Potions BuildPotion()
    {
        mediumPotion = new PotionBuilder().Name("Medium Potion")
                                          .HealAmount(15)
                                          .CostCoins(100)
                                          .Build(this);
        return mediumPotion;
    }

    public void BuyPotions()
    {
        int cost = BuildPotion().GetPotionCost();
        int hp = BuildPotion().GetHealAmount();

        if (_coinsManager.GetCoin() >= cost)
            EventManager.Instance.Trigger("OnBuyingPotions", -cost, hp);
    }


}

