using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemyOneFactory : IFactoryT<BulletEnemyOne>
{
    public BulletEnemyOne Create()
    {
        var prefab = Resources.Load<BulletEnemyOne>("bulletEnemyOne");
        return GameObject.Instantiate(prefab);
    }
}
