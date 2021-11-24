using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public int bulletDamage;
    public float fireRate;

    public virtual void Shoot() //Dispara
    {
        
    }

    public virtual void Get() //Llama al elemento desde su pool
    {

    }

}
