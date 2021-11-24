using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Asteroid : MonoBehaviour, IMovable
{
    private float speed;
    [SerializeField] private float maxVel = 0, minVel = 0;
    [SerializeField] private float spawnXMin = 0, spawnXMax = 0, spawnYMin = 0, spawnYMax = 0;
    private Vector3 _velocity;
    private float _internalSpeedModifier;
    public ObjectPool<Asteroid> ap;
    private int bulletLayer = 8;
    private int misilLayer = 9;
    [SerializeField] private int _scoreCost = 0, _dmgDone = 0; //Dependientes del tipo de asteroide

    void OnEnable() //Configuracion inicial
    {
        _internalSpeedModifier = 1;
        transform.position = new Vector3(UnityEngine.Random.Range(spawnXMin, spawnXMax), UnityEngine.Random.Range(spawnYMin, spawnYMax), 0); //Cualquiera de los spawns random
        Vector3 randomDirection = new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f), 0); //Direcion
        speed = UnityEngine.Random.Range(minVel, maxVel);
        randomDirection.Normalize();
        randomDirection *= speed;
        AddForce(randomDirection);

    }


    public void Update()
    {
        Move(_velocity, _internalSpeedModifier);
        CheckBounds();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == bulletLayer || other.gameObject.layer == misilLayer) //Si colisiono con cualquiera de esas 2 layermasks vuelvo al pool el asteroide
        {
            ap.Return(this);

            EventManager.Instance.Trigger("OnDestroyingAsteroid", _scoreCost);
        }


        if(other.gameObject.tag == "Player")
        {
            ap.Return(this);

            EventManager.Instance.Trigger("OnGettingHit", _dmgDone);
        }



    }

    void AddForce(Vector3 force)
    {
        _velocity += force;
        _velocity = Vector3.ClampMagnitude(_velocity, speed);

    }

    public void CheckBounds() //Funcion que revisa que cuando se pasen de la pantalla vuelvan por el otro lado
    {
        if (transform.position.y > 6) transform.position = new Vector3(transform.position.x, -6, transform.position.z );
        if (transform.position.y < -6) transform.position = new Vector3(transform.position.x, 6, transform.position.z);
        if (transform.position.x < -10f) transform.position = new Vector3(10f, transform.position.y, transform.position.z);
        if (transform.position.x > 10f) transform.position = new Vector3(-10f, transform.position.y, transform.position.z);
    }

    public void Move(Vector3 direction, float speed)
    {
        transform.position += direction * speed * Time.deltaTime;
    }

}
