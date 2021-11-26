using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOnePool : Weapon, ITurnsTP<BulletEnemyOne, BulletEnemyOne>
{
    private ObjectPool<BulletEnemyOne> _poolBullets;//Pool 
    private IFactoryT<BulletEnemyOne> _bulletFact; //Factory
    float _spawnTimer;
    public void Awake()
    {
        _bulletFact = new BulletEnemyOneFactory();
        _poolBullets = new ObjectPool<BulletEnemyOne>(_bulletFact.Create, TurnOff, TurnOn, ammount);
    }
    public override void Get()
    {

        var bullet = _poolBullets.Get();
        bullet.transform.position = transform.position;
        bullet.bp = _poolBullets;
        
    }
    public void Update()
    {
        Shoot();
    }
    public override void Shoot() //Un on update
    {
        _spawnTimer -= Time.deltaTime;
        if (_spawnTimer < 0)
        {
            Get();
            _spawnTimer = fireRate;
        }
    }
    public BulletEnemyOne TurnOn(BulletEnemyOne A)
    {
        A.gameObject.SetActive(true);
        return (A);
    }

    public BulletEnemyOne TurnOff(BulletEnemyOne A)
    {
        A.gameObject.SetActive(false);
        return A;
    }
}
