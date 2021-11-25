using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyweightPointer
{
    public static readonly Flyweight bullet = new Flyweight
    {
        speed = 1,
        asteroidsLayer = 10,
        boundsLayer = 11,
    };
    public static readonly Flyweight misil = new Flyweight
    {
        speed = 10,
        asteroidsLayer = 10,
        boundsLayer = 11,
    };
}
