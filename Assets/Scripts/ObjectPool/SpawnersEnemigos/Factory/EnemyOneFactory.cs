using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOneFactory : IFactoryT<EnemyOne>
{
    public EnemyOne Create()
    {
        var prefab = Resources.Load<EnemyOne>("enemyOne");
        return GameObject.Instantiate(prefab);
    }
}
