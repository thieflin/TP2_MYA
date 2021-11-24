using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsManager : MonoBehaviour
{

    private int _coins;
    public Text coinsText;
    //Este script lo unico que hace es sumar cantidad de monedas con un evento
    public void Start()
    {
        EventManager.Instance.Subscribe("OnGettingCoin", UpdateCoins);

        EventManager.Instance.Subscribe("OnBuyingPotions", UpdateCoins);
    }

    private void UpdateCoins(params object[] parameters) //Updatea las coins
    {
        _coins += (int)parameters[0];
        coinsText.text = _coins.ToString();
    }

    public void UnSubscribeCoinGet(params object[] parameters) //Reset para evitar bugs
    {
        EventManager.Instance.Unsubscribe("OnGettingCoin", UpdateCoins);
    }
    public int GetCoin()
    {
        return _coins;
    }
}
