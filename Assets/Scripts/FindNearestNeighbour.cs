using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindNearestNeighbour : MonoBehaviour
{

    public static List<FindNearestNeighbour> ExistingNeighbours = new List<FindNearestNeighbour>();
    public static List<Vector3> NeighboursPosition = new List<Vector3>();
    
    public int index;
    public bool isEnabled;

    public void OnEnable()
    {
        isEnabled = true;
        index = ExistingNeighbours.Count;
        ExistingNeighbours.Add(this);
        NeighboursPosition.Add(this.transform.position);
    }

    public void OnDisable()
    {
        isEnabled = false;

    }

    void UpdatePosition()
    {
        NeighboursPosition[index] = transform.position;
    }

    private Vector3 FindNearest()
    {
        if (NeighboursPosition.Count <= 1)
        {

            return Vector3.zero;
        }
        var lowestDistance = float.MaxValue;
        var lowestIndex = -1;
        for (var i = 0; i < NeighboursPosition.Count; i++)
        {
            if (index == i || ExistingNeighbours[i].isEnabled == false)
                continue;
            
            var curDistance = Vector3.Distance(NeighboursPosition[i], transform.position);
            if (curDistance < lowestDistance)
            {
                lowestDistance = curDistance;
                lowestIndex = i;
            }
            
        }
        return lowestIndex == -1 ? Vector3.zero : NeighboursPosition[lowestIndex];
    }

    public void Update()
    {
        UpdatePosition();
        Debug.DrawLine(transform.position, FindNearest());
    }
}
