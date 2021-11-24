using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsPool : MonoBehaviour, ITurnsTP<Asteroid,Asteroid>, ISpawners
{
    public ObjectPool<Asteroid> poolAsteroids;//Pool
    private IFactoryT<Asteroid> _asteroidFactory; //Factory
    [SerializeField] private int _firstSpawn = 0;//Cuantos quiero que spawnee la primer vez
    [SerializeField] private float _timeToFirstSpawn = 0; //Cuanto quiero que tarde en re-spawnear la primer   vez
    [SerializeField] private int _maxSpawn = 0, _minSpawn = 0; //Minima y maxima cantidad de asteroides que voy a aspawnear
    private float _spawnTimer;//Tiempo de spawneo
    [SerializeField] private int _minTimeToSpawn = 0, _maxTimeToSpawn = 0; //Random para que spawnee entre ciertos tiempos
    [SerializeField] private int _initialAsteroids = 0; //Pool de asteroides inicial


    public void Awake()
    {
        _asteroidFactory = new AsteroidFactory();
        poolAsteroids = new ObjectPool<Asteroid>(_asteroidFactory.Create, TurnOff, TurnOn, _initialAsteroids);
        _spawnTimer = _timeToFirstSpawn;
    }
    public void Start()
    {
        FirstSpawn();
    }

    public void Update()
    {
        OnUpdate();
    }

    //Funciones de la interfaz ITurns, se encargan de prender y apagar los elementos del pool

    public Asteroid TurnOn(Asteroid A)
    {
        A.gameObject.SetActive(true);
        return (A);
    }

    public Asteroid TurnOff(Asteroid A)
    {
        A.gameObject.SetActive(false);
        return A;
    }

    //Funciones de la interfaz de Spawners, se encargan de el primer spawn, el Get del pool y loopear
    public void GetElement()
    {
        var asteroid = poolAsteroids.Get();
        asteroid.ap = poolAsteroids;
    }
    public void OnUpdate() //Un on update
    {
        _spawnTimer -= Time.deltaTime;
        if (_spawnTimer < 0)
        {
            Looping();
            _spawnTimer = UnityEngine.Random.Range(_minTimeToSpawn, _maxTimeToSpawn); //Cujanto quiero que tarde en el proximo spawn
        }
    }

    // Funciones de loopeo
    public void FirstSpawn() //El primer spawneo
    {
        for (int i = 0; i < _firstSpawn; i++)
        {
            GetElement();
        }
    }

    public void Looping() //El loopeo para que siga spawneando una cierta cantidad
    {
        for (int i = 0; i < Random.Range(_minSpawn, _maxSpawn); i++)
        {
            GetElement();
        }
    }

}
