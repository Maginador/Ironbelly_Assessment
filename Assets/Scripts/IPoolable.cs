using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolable
{
     void ActivatePoolable();
     void InactivatePoolable();

     void InitializeObject();
}
