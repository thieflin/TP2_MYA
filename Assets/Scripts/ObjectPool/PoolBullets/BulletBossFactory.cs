using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBossFactory : IFactoryT<BulletBoss>
{
    public BulletBoss Create()
    {
        var prefab = Resources.Load<BulletBoss>("bossbullet");
        return GameObject.Instantiate(prefab);
    }
}
