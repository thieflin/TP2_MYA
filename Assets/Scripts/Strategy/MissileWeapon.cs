using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileWeapon : Weapon, ITurnsTP<Misil, Misil>
{

    public ObjectPool<Misil> poolMisil;
    private IFactoryT<Misil> _factoryMisils;
    public void Awake()
    {
        _factoryMisils = new MisilFactory();
        poolMisil = new ObjectPool<Misil>(_factoryMisils.Create, TurnOff, TurnOn, ammount);
    }
    public override void Shoot()//Funcion heredada de Weapon, dispara
    {
        Get(); //Llama al misil
    }

    public override void Get() //Llamo al misil y lo guardo en su pool para poder retornarlo
    {
        var misil = poolMisil.Get();
        misil.mp = poolMisil;
        misil.transform.position = transform.position;
    }

    //funcs <t,t> de prender y apagar de la interfaz

    public Misil TurnOn(Misil m)
    {
        m.gameObject.SetActive(true);
        return m;
    }

    public Misil TurnOff(Misil m)
    {
        m.gameObject.SetActive(false);
        return m;
    }
}
