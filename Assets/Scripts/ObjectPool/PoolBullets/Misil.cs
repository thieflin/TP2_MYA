using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misil : MonoBehaviour
{
    public ObjectPool<Misil> mp;
    [SerializeField] private int maxHp = 0;
    private int misilHp;

    public void OnEnable()
    {
        misilHp = maxHp;
    }

    public void Update() 
    {
        transform.position += Vector3.up * Time.deltaTime * FlyweightPointer.misil.speed;
    }

    public void OnTriggerEnter(Collider other) //Si colision con layer asteroids, retorno el misil al pool
    {
        if (other.gameObject.layer == FlyweightPointer.misil.asteroidsLayer) //Devuelve al pool cuando colisiona con un asteroide
        {
            misilHp --;
            if(misilHp == 0)
            {
                mp.Return(this);
            }
        }

        if(other.gameObject.layer == FlyweightPointer.misil.boundsLayer) //Devuelve al pool cuando colisiona con los bounds
        {
            mp.Return(this);
        }
    }

}
