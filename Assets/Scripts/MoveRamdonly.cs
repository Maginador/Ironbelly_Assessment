using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;

public class MoveRamdonly : MonoBehaviour
{

    public float speed;
    public static Vector3 randomSpace;

    private Vector3 _target;
    private float _threashold = 0.1f;


    private void Awake()
    {
        GetNewPosition();
        randomSpace = new Vector3(3, 3, 3);
    }

    public void GetNewPosition()
    {

        var randomX = Random.Range(randomSpace.x, -randomSpace.x);
        var randomY = Random.Range(randomSpace.y, -randomSpace.y);
        var randomZ = Random.Range(randomSpace.z, -randomSpace.z);
        _target = new Vector3(randomX, randomY, randomZ);
    }

    public void Update()
    {
        if(Vector3.Distance(transform.position, _target) < _threashold)
            GetNewPosition();
        
        Move();
        
    }

    private void Move()
    {
        transform.Translate((_target-transform.position).normalized * (speed * Time.deltaTime));
    }
}
