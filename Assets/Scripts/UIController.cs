using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text nValue, xValue, yValue, zValue;
    public Pool pool;
    public GameObject[] boundsObjects;
    public void Start()
    {
        xValue.text = MoveRamdonly.RandomSpace.x.ToString();
        yValue.text = MoveRamdonly.RandomSpace.y.ToString();
        zValue.text = MoveRamdonly.RandomSpace.z.ToString();
        MoveRamdonly.DrawBounds(boundsObjects);

    }

    public void UpdateBoundingArea()
    {
        try
        {
            MoveRamdonly.RandomSpace = new Vector3(float.Parse(xValue.text), float.Parse(yValue.text), float.Parse(zValue.text));
        }
        catch
        {
            Debug.LogError("Text Fields should only have numbers!!");
        }
        MoveRamdonly.SpaceUpdated.Invoke();
        MoveRamdonly.DrawBounds(boundsObjects);

    }
    public void AddElements(bool useN)
    {
        var quantity = 1;
        if (useN)
        {
            try
            {
                quantity = Int32.Parse(nValue.text);
            }
            catch
            {
                Debug.LogError("Text Field should only have numbers!!");
            }
        }
        
        pool.AddElements(quantity);
    }
    
    public void RemoveElement(bool useN)
    {
        var quantity = 1;
        if (useN)
        {
            try
            {
                quantity = int.Parse(nValue.text);
            }
            catch
            {
                Debug.LogError("Text Field should only have numbers!!");
            }
        }
        
        pool.RemoveElements(quantity);
    }

    public void Update()
    {
    }
}
