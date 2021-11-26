using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTwoFactory : IFactoryT<EnemyTwo>
{
    public EnemyTwo Create()
    {
        var prefab = Resources.Load<EnemyTwo>("enemyTwo");
        return GameObject.Instantiate(prefab);
    }
}
