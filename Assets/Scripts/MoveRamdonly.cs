using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using Object = System.Object;
using Random = UnityEngine.Random;

public class MoveRamdonly : MonoBehaviour
{

    public float speed;
    public static Vector3 RandomSpace = new Vector3(3, 3, 3);

    private Vector3 _target;
    private float _threashold = 0.1f;


    private void Awake()
    {
        _target = GetNewPosition();
        
    }

    public static Vector3 GetNewPosition()
    {

        var randomX = Random.Range(RandomSpace.x, -RandomSpace.x);
        var randomY = Random.Range(RandomSpace.y, -RandomSpace.y);
        var randomZ = Random.Range(RandomSpace.z, -RandomSpace.z);
        return new Vector3(randomX, randomY, randomZ);
    }

    public void Update()
    {
        if (Vector3.Distance(transform.position, _target) < _threashold)
        {
            _target = GetNewPosition();
        }

        Move();
        
    }

    private void Move()
    {
        transform.Translate((_target-transform.position).normalized * (speed * Time.deltaTime));
    }

    public static void DrawBounds(GameObject[] objects)
    {

        var scale = RandomSpace / 100;

        foreach (var obj in objects)
        {
            obj.transform.parent.localScale = scale;
        }
        //Upper Part
        objects[0].transform.position = new Vector3(RandomSpace.x, RandomSpace.y, -RandomSpace.z);
        objects[1].transform.position = new Vector3(-RandomSpace.x, RandomSpace.y, -RandomSpace.z);
        objects[2].transform.position = new Vector3(RandomSpace.x, RandomSpace.y, RandomSpace.z);
        objects[3].transform.position = new Vector3(-RandomSpace.x, RandomSpace.y, RandomSpace.z);
        //Lower Part
        objects[4].transform.position = new Vector3(RandomSpace.x, -RandomSpace.y, -RandomSpace.z);
        objects[5].transform.position = new Vector3(-RandomSpace.x, -RandomSpace.y, -RandomSpace.z);
        objects[6].transform.position = new Vector3(RandomSpace.x, -RandomSpace.y, RandomSpace.z);
        objects[7].transform.position = new Vector3(-RandomSpace.x, -RandomSpace.y, RandomSpace.z);

    }

}
