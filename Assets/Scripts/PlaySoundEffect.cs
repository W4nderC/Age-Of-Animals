using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundEffect : MonoBehaviour
{
    public static event EventHandler OnAnySelfDestruct;
    public static event EventHandler OnAnyBtnPressed;
    
    public void InvokeOnAnySelfDestruct()
    {
        OnAnySelfDestruct?.Invoke(this, EventArgs.Empty);
    }

    public void InvokeOnAnyBtnPressed()
    {
        OnAnyBtnPressed?.Invoke(this, EventArgs.Empty);
    }
}
