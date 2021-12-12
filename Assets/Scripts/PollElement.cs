using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class PollElement : MonoBehaviour, IPoolable
{
    public void ActivatePoolable()
    {
        transform.position = MoveRamdonly.GetNewPosition();
        gameObject.SetActive(true);
        
    }

    public void InactivatePoolable()
    {
        gameObject.SetActive(false);
    }

    public void InitializeObject()
    {
        
    }
}
