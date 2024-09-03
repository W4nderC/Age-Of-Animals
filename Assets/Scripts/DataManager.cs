using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set; }

    // SpawnPlayer
    [HideInInspector] public int currentNumberOfNormalClone;
    [HideInInspector] public int currentNumberOfAdvanceClone;
    [HideInInspector] public int currentNumberOfHardClone;
    [HideInInspector] public int currentNumberOfSubClone;
    [HideInInspector] public int currentNumberOfBossClone;
    [HideInInspector] public int currentNumberOfClone;

    // CheckPoint
    [HideInInspector] public int math;
    [HideInInspector] public int equationResult;

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
