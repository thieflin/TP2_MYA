using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicWeapon : Weapon, ITurnsTP<Bullet,Bullet>
{
    public ObjectPool<Bullet> poolBullets;
    private IFactoryT<Bullet> _factoryBullets;
    [SerializeField] private int ammount = 0;
    public void Awake()
    {
        _factoryBullets = new BulletFactory();
        poolBullets = new ObjectPool<Bullet>(_factoryBullets.Create, TurnOff, TurnOn, ammount);
    }

    public override void Shoot()//Funcion heredada de Weapon, dispara
    {
        Get(); //Llama al misil
    }

    public override void Get() //Llamo al misil y lo guardo en su pool para poder retornarlo
    {
        var bullet = poolBullets.Get();
        bullet.bp = poolBullets;
        bullet.transform.position = transform.position; //La hago spawnearse en donde esta el player
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
}
