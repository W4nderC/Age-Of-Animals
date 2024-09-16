using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnPlayer : MonoBehaviour
{
    [Header("CloneSO")]
    [SerializeField] private PlayerCloneScriptableObject normalCloneSO;
    [SerializeField] private PlayerCloneScriptableObject advanceCloneSO;
    [SerializeField] private PlayerCloneScriptableObject hardCloneSO;
    [SerializeField] private PlayerCloneScriptableObject subCloneSO;
    [SerializeField] private PlayerCloneScriptableObject bossCloneSO;

    [Header("Max Clone Allow")]
    [SerializeField] private int maxNumberOfNormalClone; // 10
    [SerializeField] private int maxNumberOfAdvanceClone; // 5
    [SerializeField] private int maxNumberOfHardClone; // 2
    [SerializeField] private int maxNumberOfSubClone; // 5
    [SerializeField] private int maxNumberOfBossClone; // 2

    private GameObject[] normalCloneArray = new GameObject[10];
    private GameObject[] advanceCloneArray = new GameObject[5];
    private GameObject[] hardCloneArray = new GameObject[2];
    private GameObject[] subCloneArray = new GameObject[5];
    private GameObject[] bossCloneArray = new GameObject[2];
    
    private int currentNumberOfNormalClone;
    private int currentNumberOfAdvanceClone;
    private int currentNumberOfHardClone;
    private int currentNumberOfSubClone;
    private int currentNumberOfBossClone;
    private int currentNumberOfClone;

    void Update()
    {
        currentNumberOfNormalClone = GameObject.FindObjectsOfType<NormalClone>().Length;
        currentNumberOfAdvanceClone = GameObject.FindObjectsOfType<AdvanceClone>().Length;
        currentNumberOfHardClone = GameObject.FindObjectsOfType<HardClone>().Length;
        currentNumberOfSubClone = GameObject.FindObjectsOfType<SubClone>().Length;
        currentNumberOfBossClone = GameObject.FindObjectsOfType<BossClone>().Length;

        currentNumberOfClone = currentNumberOfNormalClone + currentNumberOfAdvanceClone*10 
        + currentNumberOfHardClone*50 + currentNumberOfSubClone*100 + currentNumberOfBossClone*500;
        
        DataManager.Instance.currentNumberOfNormalClone = currentNumberOfNormalClone;
        DataManager.Instance.currentNumberOfAdvanceClone = currentNumberOfAdvanceClone;
        DataManager.Instance.currentNumberOfHardClone = currentNumberOfHardClone;
        DataManager.Instance.currentNumberOfSubClone = currentNumberOfSubClone;
        DataManager.Instance.currentNumberOfBossClone = currentNumberOfBossClone;
        DataManager.Instance.currentNumberOfClone = currentNumberOfClone;
        
    }

    public void SpawnCloneHandler()
    {
        currentNumberOfClone = DataManager.Instance.currentNumberOfClone;

        int numberNormalCloneSpawn = 0;
        int numberAdvanceCloneSpawn = 0;
        int numberHardCloneSpawn = 0;
        int numberSubCloneSpawn = 0;


        int math = DataManager.Instance.math;
        int equationResult = DataManager.Instance.equationResult;
        int newNumberOfClone = NewNumberOfClone(math, equationResult, currentNumberOfClone);


        //Destroy all Clone
        DestroyClone(normalCloneArray, StringList.NORMAL_CLONE);
        DestroyClone(advanceCloneArray, StringList.ADVANCE_CLONE);
        DestroyClone(hardCloneArray, StringList.HARD_CLONE);
        DestroyClone(subCloneArray, StringList.SUB_CLONE);
        DestroyClone(bossCloneArray, StringList.BOSS_CLONE);

        for (int i = 0; i < newNumberOfClone; i++)
        {
            SpawnNormalClone();
            numberNormalCloneSpawn++;
            if(numberNormalCloneSpawn == maxNumberOfNormalClone) 
            {
                SpawnAdvanceClone();
                numberAdvanceCloneSpawn++;
                numberNormalCloneSpawn = 0;
            }
            if(numberAdvanceCloneSpawn == maxNumberOfAdvanceClone) 
            {
                SpawnHardClone();
                numberHardCloneSpawn++;
                numberAdvanceCloneSpawn = 0;
            }
            if(numberHardCloneSpawn == maxNumberOfHardClone) 
            {
                SpawnSubClone();
                numberSubCloneSpawn++;
                numberHardCloneSpawn = 0;
            }
            if(numberSubCloneSpawn == maxNumberOfSubClone) 
            {
                SpawnBossClone();
                numberSubCloneSpawn = 0;
            }
        }
        
    }

    public void SpawnNormalClone()
    {   
        SpawnClone(normalCloneSO.playerClonePrefab);
    }

    public void SpawnAdvanceClone()
    {        
        DestroyClone(normalCloneArray, StringList.NORMAL_CLONE);
        SpawnClone(advanceCloneSO.playerClonePrefab);      
    }

    public void SpawnHardClone()
    {        
        DestroyClone(advanceCloneArray, StringList.ADVANCE_CLONE);
        SpawnClone(hardCloneSO.playerClonePrefab);    
        
    }

    public void SpawnSubClone()
    {        
        DestroyClone(hardCloneArray, StringList.HARD_CLONE);
        SpawnClone(subCloneSO.playerClonePrefab);    
        
    }

    public void SpawnBossClone()
    {        
        DestroyClone(subCloneArray, StringList.SUB_CLONE);
        SpawnClone(bossCloneSO.playerClonePrefab);    
        
    }

    private void DestroyClone(GameObject[] cloneArray, string cloneName)
    {
        cloneArray = GameObject.FindGameObjectsWithTag(cloneName);
        for (int i = 0; i < cloneArray.Length; i++)
        {
            Destroy(cloneArray[i]);
        }
    }

    private void SpawnClone(GameObject clonePrefab)
    {                
        UnityEngine.Vector3 position = new UnityEngine.Vector3(Random.Range(-3, 3), 0.001f, -6);
        Instantiate(clonePrefab, position, UnityEngine.Quaternion.identity);

    }

    private int NewNumberOfClone(int math, int equationResult, int currentNumberOfClone)
    {
        int newNumberOfClone = 0;
        if(math == 0) // Add
        {
            newNumberOfClone = currentNumberOfClone + equationResult;
        } 
        else if (math == 1) // Sub
        {
            newNumberOfClone = currentNumberOfClone - equationResult;
        }
        else if (math == 2) // Mul
        {
            newNumberOfClone = currentNumberOfClone * equationResult;
        }
        else if (math == 3) // Div
        {
            newNumberOfClone = currentNumberOfClone / equationResult;
        }
        else if (math == 4) // Equal
        {
            newNumberOfClone = currentNumberOfClone = equationResult;
        }
        return newNumberOfClone;
    }

}
