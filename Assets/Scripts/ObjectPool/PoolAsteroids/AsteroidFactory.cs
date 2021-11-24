using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidFactory : IFactoryT<Asteroid>
{

    public Asteroid Create()
    {
        var prefab = Resources.Load<Asteroid>("asteroid");
        return GameObject.Instantiate(prefab);
    }
    
}
