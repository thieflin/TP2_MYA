using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemyOne : MonoBehaviour, ITurnsTP<EnemyOne, EnemyOne>
{
    public ObjectPool<EnemyOne> poolEnemigos;//Pool
    private IFactoryT<EnemyOne> _enemyFactory; //Factory
    [SerializeField] private int _ammount;
    [SerializeField] private int initialPosX = 0, initialPosY; //Grid width
    [SerializeField] private float corrimiento = 0; //La distancia de la grid


    public void Awake()
    {
        _enemyFactory = new EnemyOneFactory();
        poolEnemigos = new ObjectPool<EnemyOne>(_enemyFactory.Create, TurnOff, TurnOn, _ammount);
    }
    public void Start()
    {
        for (int i = 0; i < _ammount; i++)
        {
            Vector3 pos = new Vector3(initialPosX + corrimiento*i, initialPosY, 0);
            var enemy = poolEnemigos.Get();
            enemy.transform.position = pos;
            enemy.eo = poolEnemigos;
        }

    }

    //Funciones de la interfaz ITurns, se encargan de prender y apagar los elementos del pool

    public EnemyOne TurnOn(EnemyOne A)
    {
        A.gameObject.SetActive(true);
        return (A);
    }

    public EnemyOne TurnOff(EnemyOne A)
    {
        A.gameObject.SetActive(false);
        return A;
    }
}