using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicWeapon : Weapon, ITurnsTP<Bullet, Bullet>
{
    public ObjectPool<Bullet> poolBullets;
    private IFactoryT<Bullet> _factoryBullets;
    [SerializeField] private int _ammount = 0;
    [SerializeField] private int _bulletAmmount = 0;
    [SerializeField] private float _startAngle = 0, _endAngle = 0, radious = 0,rotate = 0;
    [SerializeField] private float algo; //Algo es un grado
    public void Awake()
    {
        _factoryBullets = new BulletFactory();
        poolBullets = new ObjectPool<Bullet>(_factoryBullets.Create, TurnOff, TurnOn, _ammount);
    }
    public override void Shoot()//Funcion heredada de Weapon, dispara
    {
        Get(); //Llama al misil
    }
    public override void Get() //Llamo al misil y lo guardo en su pool para poder retornarlo
    {
        for (int i = 0; i < _bulletAmmount; i++)
        {
            float y = transform.position.y + Mathf.Sin(((_startAngle + algo*i) * Mathf.PI) / radious);
            float x = transform.position.x + Mathf.Cos(((_startAngle + algo*i) * Mathf.PI) / radious);
            Vector3 offset = new Vector3(x, y, 0);
            Vector3 dir = (offset - transform.position).normalized;
            var bullet = poolBullets.Get();
            bullet.bp = poolBullets;
            bullet.transform.position = transform.position + dir; //La hago spawnearse en donde esta el player
            bullet.transform.forward = dir;
            
        }
        _startAngle += rotate;
        if (_startAngle > radious*2 - rotate)
            _startAngle = 0;
    }

    //funcs <t,t> de prender y apagar

    public Bullet TurnOn(Bullet b)
    {
        b.gameObject.SetActive(true);
        return b;
    }

    public Bullet TurnOff(Bullet b)
    {
        b.gameObject.SetActive(false);
        return b;
    }


    //Tiro triple
    /*
     * float angleStep = (_endAngle - _startAngle) / _bulletAmmount;
        float angle = _startAngle;
        for (int i = 0; i < _bulletAmmount; i++)
        {
            float y = transform.position.y + Mathf.Sin((angle * Mathf.PI)*odna / radious)*amplitud ;
            float x = transform.position.x + Mathf.Cos((angle * Mathf.PI)*odna / radious) * amplitud;
            Vector3 offset = new Vector3(x, y, 0);
            Vector3 dir = (offset - transform.position).normalized;
            var bullet = poolBullets.Get();
            bullet.bp = poolBullets;
            bullet.transform.position = transform.position + dir; //La hago spawnearse en donde esta el player
            bullet.transform.forward = dir;
            angle += angleStep;
        }
        */
}