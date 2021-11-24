using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IFactoryTP<T, P> //Factory con parametro
{
    T Create(P parameter);
}

