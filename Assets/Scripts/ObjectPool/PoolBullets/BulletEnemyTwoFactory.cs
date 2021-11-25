using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemyTwoFactory : IFactoryT<BulletEnemyTwo>
{
    public BulletEnemyTwo Create()
    {
        var prefab = Resources.Load<BulletEnemyTwo>("bulletEnemyTwo");
        return GameObject.Instantiate(prefab);
    }
}
