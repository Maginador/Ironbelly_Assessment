using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public InputField xField, yField, zField;
    public Text nValue;
    public Pool pool;
    public GameObject[] boundsObjects;
    public void Start()
    {
        xField.SetTextWithoutNotify(MoveRamdonly.RandomSpace.x.ToString());
        yField.SetTextWithoutNotify(MoveRamdonly.RandomSpace.y.ToString());
        zField.SetTextWithoutNotify(MoveRamdonly.RandomSpace.z.ToString());
        MoveRamdonly.DrawBounds(boundsObjects);

    }

    public void UpdateBoundingArea()
    {
        try
        {
            MoveRamdonly.RandomSpace = new Vector3(float.Parse(xField.text), float.Parse(yField.text), float.Parse(zField.text));
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
