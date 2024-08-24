using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringList : MonoBehaviour
{
    public static StringList Instance { get; private set; }
    // GameObject tag
    public const string PLAYER = "Player";
    public const string NORMAL_CLONE = "NormalClone";
    public const string ADVANCE_CLONE = "AdvanceClone";
    // GameObject CheckPoint name
    public const string SEC_CHECKPOINT_LEFT = "SecondCheckPointLeft";
    public const string SEC_CHECKPOINT_RIGHT = "SecondCheckPointRight";
    public const string FIR_CHECKPOINT_LEFT = "FirstCheckPointLeft";
    public const string FIR_CHECKPOINT_RIGHT = "FirstCheckPointRight";

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
}
