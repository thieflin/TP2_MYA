using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public ObjectPool<Bullet> bp; //Object pool de las balas para poder tener la referencia y retornarlas

    public void Update()
    {
        transform.position += Vector3.up * Time.deltaTime * FlyweightPointer.bullet.speed;

    }

    public void OnTriggerEnter(Collider other) //Si colision con layer asteroids o los bounds, retorno la bala al pool
    {
        if(other.gameObject.layer == FlyweightPointer.bullet.asteroidsLayer || other.gameObject.layer == FlyweightPointer.bullet.boundsLayer)
        {
            bp.Return(this);
        }

    }

}
