using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFactory : IFactoryT<Bullet>
{
    public Bullet Create() //Factory de balas 
    {
        var prefab = Resources.Load<Bullet>("bullet");
        return GameObject.Instantiate(prefab);
    }
}
