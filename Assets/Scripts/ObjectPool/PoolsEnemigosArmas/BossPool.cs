using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPool : Weapon, ITurnsTP<BulletBoss, BulletBoss>
{
    public ObjectPool<BulletBoss> poolBossBullets;//Pool
    private IFactoryT<BulletBoss> _bulletBossFactory; //Factory
    private float _spawnTimer; //Tiempo para cada bala que va a tirar
    [Header("Patron de disparo")]
    [SerializeField] private float _startAngle = 0;
    [SerializeField] private float radious = 0;
    [SerializeField] private float rotate = 0;
    [SerializeField] private float algo = 0;


    public void Awake()
    {
        _bulletBossFactory = new BulletBossFactory();
        poolBossBullets = new ObjectPool<BulletBoss>(_bulletBossFactory.Create, TurnOff, TurnOn, ammount);
    }
    public void Start()
    {
        _spawnTimer = fireRate;

    }
    public void Update()
    {
        Shoot();
    }

    //Funciones de la interfaz ITurns, se encargan de prender y apagar los elementos del pool

    public BulletBoss TurnOn(BulletBoss A)
    {
        A.gameObject.SetActive(true);
        return (A);
    }

    public BulletBoss TurnOff(BulletBoss A)
    {
        A.gameObject.SetActive(false);
        return A;
    }

    //Funciones de la interfaz de Spawners, se encargan de el primer spawn, el Get del pool y loopear
    public override void Get()
    {
        for (int i = 0; i < ammount; i++)
        {
            float y = transform.position.y + Mathf.Sin(((_startAngle + algo * i) * Mathf.PI) / radious);
            float x = transform.position.x + Mathf.Cos(((_startAngle + algo * i) * Mathf.PI) / radious);
            Vector3 offset = new Vector3(x, y, 0);
            Vector3 dir = (offset - transform.position).normalized;
            var bossbullet = poolBossBullets.Get();
            bossbullet.bbp = poolBossBullets;
            bossbullet.transform.position = transform.position + dir; //La hago spawnearse en donde esta el player
            bossbullet.transform.forward = dir;

        }
        _startAngle += rotate;
        if (_startAngle > radious * 2 - rotate)
            _startAngle = 0;
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
}
