using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySound : MonoBehaviour
{
    public static event EventHandler OnAnySelfDestruct;

    
    public void InvokeOnAnySelfDestruct()
    {
        OnAnySelfDestruct?.Invoke(this, EventArgs.Empty);
    }
}
