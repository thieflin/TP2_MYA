using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTwo : MonoBehaviour
{
    public ObjectPool<EnemyTwo> bet;
    private float movement;
    public void Update()
    {
        movement += Time.deltaTime;


        float x = Mathf.Cos(movement) * 5;
        float y = Mathf.Sin(movement) * 5;
        transform.position = new Vector3(x, y, 0);
        //transform.forward = new Vector3(x, y, 0);
        //transform.position = transform.forward;
    }
}
