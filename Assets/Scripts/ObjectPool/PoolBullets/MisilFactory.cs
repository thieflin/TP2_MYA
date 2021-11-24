using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisilFactory : IFactoryT<Misil>
{
    public Misil Create() //Factory de balas 
    {
        var prefab = Resources.Load<Misil>("misil");
        return GameObject.Instantiate(prefab);
    }
}