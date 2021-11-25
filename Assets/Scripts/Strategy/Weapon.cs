using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public float fireRate;
    public int ammount;

    public virtual void Shoot() //Dispara
    {
        
    }

    public virtual void Get() //Llama al elemento desde su pool
    {

    }

}
