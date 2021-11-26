using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemyTwo : MonoBehaviour, ITurnsTP<EnemyTwo, EnemyTwo>
{
    private ObjectPool<EnemyTwo> _poolEnemies;
    private IFactoryT<EnemyTwo> _factEnemy;
    [SerializeField] private int _ammount;
    [SerializeField] private float _startAngle = 0;
    [SerializeField] private float radious = 0;
    [SerializeField] private float rotate = 0;
    [SerializeField] private float algo = 0;

    private void Awake()
    {
        _factEnemy = new EnemyTwoFactory();
        _poolEnemies = new ObjectPool<EnemyTwo>(_factEnemy.Create, TurnOff, TurnOn, _ammount);
    }

    public void Start()
    {
        float radius = 8;
        for (int i = 0; i < _ammount; i++)
        {
            float angle = i * Mathf.PI * 2f / _ammount;
            Vector3 newPos = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);
            var enemy = _poolEnemies.Get();
            enemy.bet = _poolEnemies;
            enemy.transform.position = transform.position + newPos * radius; //La hago spawnearse en donde esta el player
            enemy.transform.forward = newPos;
        }
    }



    public EnemyTwo TurnOff(EnemyTwo e)
    {
        e.gameObject.SetActive(false);
        return e;
    }

    public EnemyTwo TurnOn(EnemyTwo e)
    {
        e.gameObject.SetActive(true);
        return (e);
    }


    // Update is called once per frame
    void Update()
    {

    }
}
