using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
    [HideInInspector] public int newNumberOfClone;

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

    void Start()
    {
        CurrentNumOfClone();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CurrentNumOfClone()
    {
        currentNumberOfNormalClone = GameObject.FindGameObjectsWithTag(StringList.NORMAL_CLONE).Length;
        currentNumberOfAdvanceClone = GameObject.FindGameObjectsWithTag(StringList.ADVANCE_CLONE).Length;
        currentNumberOfHardClone = GameObject.FindGameObjectsWithTag(StringList.HARD_CLONE).Length;
        currentNumberOfSubClone = GameObject.FindGameObjectsWithTag(StringList.SUB_CLONE).Length;
        currentNumberOfBossClone = GameObject.FindGameObjectsWithTag(StringList.BOSS_CLONE).Length;

        currentNumberOfClone = currentNumberOfNormalClone + currentNumberOfAdvanceClone*10 
        + currentNumberOfHardClone*50 + currentNumberOfSubClone*100 + currentNumberOfBossClone*500;

        // currentNumberOfClone;
    }
}
