using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IMovable
{
    
    [SerializeField] private PlayerModel _model;
    public Action<float> OnMove;

    private Vector2 _direction; //Pongo direction aca porq solo se utiliza aca.
    [SerializeField] private float _speed = 0;


    private void Update()
    {
        

        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            _model.horizontalMovement = Input.GetAxis("Horizontal");
            _model.verticalMovement = Input.GetAxis("Vertical");

            _direction = new Vector2(_model.horizontalMovement, _model.verticalMovement);

            OnMove(_model.horizontalMovement);

            Move(_direction, _speed);
        }
        else
        {
            OnMove(0f);
            _model.horizontalMovement = 0f;
            _model.verticalMovement = 0f;
        }

        CheckBounds();
    }


    public void Move(Vector3 direction, float speed)
    {
        transform.position += direction * speed * Time.deltaTime;
    }
    

    public void CheckBounds() //Funcion que revisa que cuando se pasen de la pantalla vuelvan por el otro lado
    {
        if (transform.position.y > 5.3f) transform.position = new Vector3(transform.position.x, -5.3f, transform.position.z);
        if (transform.position.y < -5.3f) transform.position = new Vector3(transform.position.x, 5.3f, transform.position.z);
        if (transform.position.x < -9.15f) transform.position = new Vector3(9.15f, transform.position.y, transform.position.z);
        if (transform.position.x > 9.15f) transform.position = new Vector3(-9.15f, transform.position.y, transform.position.z);
    }
}
