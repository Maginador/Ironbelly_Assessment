using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PollElement : MonoBehaviour, IPoolable
{
    public void ActivatePoolable()
    {
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
