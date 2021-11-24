using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinFactory : IFactoryT<Coin>
{
    public Coin Create()
    {
        var prefab = Resources.Load<Coin>("coin");
        return GameObject.Instantiate(prefab);
    }
}
