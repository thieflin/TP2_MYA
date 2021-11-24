using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITurnsTP<T, P> //Esta interfaz tiene como finalidad usarse para los Object pools en la parte de prender y apagar
{
    T TurnOn(P parameter);
    T TurnOff(P parameter); 
}
