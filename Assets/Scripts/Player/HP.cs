using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HP : MonoBehaviour
{
    [SerializeField] private int startingHp = 0;
    [SerializeField] private Text hpText = null;
    private int currentHp;


    public void Start()
    {
        EventManager.Instance.Subscribe("OnGettingHit", GettingHit);
        EventManager.Instance.Subscribe("OnBuyingPotions", Healing);
        currentHp = startingHp;
        hpText.text = currentHp.ToString();
    }

    public void GettingHit(params object[] parameters)
    {
        currentHp -= (int) parameters[0];
        hpText.text = currentHp.ToString();
        if (currentHp <= 0) //Si me golpean y muero.
        {
            EventManager.Instance.Trigger("OnDeath");
        }
    }

    public void Healing(params object[] parameters)
    {
        currentHp += (int)parameters[1];
        hpText.text = currentHp.ToString();
    }

}