
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public ObjectPool<Coin> cp;
    [SerializeField] private int _coinCost = 0; //Costod e la moneda por si tuviese una super moneda

    [SerializeField] private float spawnXMin = 0, spawnXMax = 0, spawnYMin = 0, spawnYMax = 0;

    public void OnEnable() //Asi las hago variar en un rango cada vez que se vuelven a llamar
    {
        transform.position = new Vector3(UnityEngine.Random.Range(spawnXMin, spawnXMax), UnityEngine.Random.Range(spawnYMin, spawnYMax), 0);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            EventManager.Instance.Trigger("OnGettingCoin", _coinCost);
            cp.Return(this);
        }
    } 
}
  