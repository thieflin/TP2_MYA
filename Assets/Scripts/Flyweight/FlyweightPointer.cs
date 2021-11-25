using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyweightPointer
{
    public static readonly Flyweight layers = new Flyweight
    {
        playerLayer = 10,
        boundsLayer = 11,
    };
    public static readonly Flyweight bullet = new Flyweight
    {
        speed = 1,
    };
    public static readonly Flyweight misil = new Flyweight
    {
        speed = 5,

    };
    public static readonly Flyweight bossBullet = new Flyweight
    {
        speed = 1,

    };
    public static readonly Flyweight enemyOneBullet = new Flyweight
    {
        speed = 2,

    };
    public static readonly Flyweight enemyTwoBullet = new Flyweight
    {
        speed = 3,
    };
}
