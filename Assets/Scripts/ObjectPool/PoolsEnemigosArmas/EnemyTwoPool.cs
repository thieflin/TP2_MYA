using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTwoPool : Weapon, ITurnsTP<BulletEnemyTwo, BulletEnemyTwo>
{
    public BulletEnemyTwo TurnOn(BulletEnemyTwo A)
    {
        A.gameObject.SetActive(true);
        return (A);
    }

    public BulletEnemyTwo TurnOff(BulletEnemyTwo A)
    {
        A.gameObject.SetActive(false);
        return A;
    }
}
