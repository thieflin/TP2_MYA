using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class ObjectPool<T>
{
    private List<T> _uninstantiated = new List<T>(); //Lista de objetos sin instanciar
    private Func<T> _create; //Funcion que crea objetos que despues agrego
    private Func<T, T> _turnOff;
    private Func<T, T> _turnOn;
    //a la lista

    public ObjectPool(Func<T> create, Func<T, T> turnOff, Func<T, T> turnOn, int amount)
    {
        _create = create;
        _turnOff = turnOff;
        _turnOn = turnOn;

        for (int i = 0; i < amount; i++)
        {
            var element = _create(); //La funcion que crea objetos me agrega
            //los elementos a la lista
            _uninstantiated.Add(_turnOff(element));

        }
    }

    public T Get()
    {
        if (_uninstantiated.Count > 0)
        {
            var element = _uninstantiated[0];
            _uninstantiated.RemoveAt(0);
            return _turnOn(element);
        }

        var instance = _create(); //Si no tengo elementos
        return _turnOn(instance);
    }


    public void Return(T element)
    {
        _uninstantiated.Add(_turnOff(element)); //Re agrego a la lista al elemento
    }
}