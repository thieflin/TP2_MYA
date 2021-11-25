using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemyOne : MonoBehaviour
{
    public ObjectPool<BulletEnemyOne> bp; //Object pool de las balas para poder tener la referencia y retornarlas

    public void Update()
    {
        transform.position += transform.forward * Time.deltaTime * FlyweightPointer.bullet.speed; //Cambiar el flyweight
    }

    public void OnTriggerEnter(Collider other) //Si colision con layer asteroids o los bounds, retorno la bala al pool
    {
        if (other.gameObject.layer == FlyweightPointer.bullet.playerLayer || other.gameObject.layer == FlyweightPointer.bullet.boundsLayer)
        {
            bp.Return(this);
        }

    }
}
