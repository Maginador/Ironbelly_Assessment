using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{

    public Pool pool;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            pool.AddElement();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            pool.RemoveElement();

        }
    }
}
