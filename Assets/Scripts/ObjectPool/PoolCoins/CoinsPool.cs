using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsPool : MonoBehaviour, ITurnsTP<Coin, Coin>, ISpawners
{
    public ObjectPool<Coin> coinPool;
    private CoinFactory _coinFactory;
    private float _spawnTimer;
    [SerializeField] private float _timeToFirstSpawn = 0;   //Cuanto quiero que tarde el primer spawn
    [SerializeField] private float _maxTimeToSpawn = 0, _minTimeToSpawn = 0; //Maximo y minimo tiempo de spawneo en el que quiero que varie
    [SerializeField] private int _ammount = 0;


    public void Start()
    {
        _coinFactory = new CoinFactory();
        coinPool = new ObjectPool<Coin>(_coinFactory.Create, TurnOff, TurnOn, _ammount);
        _spawnTimer = _timeToFirstSpawn;
    }


    public void Update()
    {
        OnUpdate();
    }


    //Interfaz que se encarga de prender y apagar
    public Coin TurnOn(Coin C)
    {
        C.gameObject.SetActive(true);
        return (C);
    }

    public Coin TurnOff(Coin C)
    {
        C.gameObject.SetActive(false);
        return C;
    }


    //Interfaz que se encarga de loopear y llamar desdde el pool a los elementos que necesite
    public void GetElement()
    {
        var coin = coinPool.Get();
        coin.cp = coinPool;
    }

    public void OnUpdate()
    {
        _spawnTimer -= Time.deltaTime;
        if (_spawnTimer < 0)
        {
            GetElement();
            _spawnTimer = UnityEngine.Random.Range(_minTimeToSpawn, _maxTimeToSpawn);
        }
    }

}
