using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOnePool : Weapon, ITurnsTP<BulletEnemyOne, BulletEnemyOne>
{
    public BulletEnemyOne TurnOn(BulletEnemyOne A)
    {
        A.gameObject.SetActive(true);
        return (A);
    }

    public BulletEnemyOne TurnOff(BulletEnemyOne A)
    {
        A.gameObject.SetActive(false);
        return A;
    }
}
