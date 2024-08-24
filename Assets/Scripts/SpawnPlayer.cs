using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnPlayer : MonoBehaviour
{
    [Header("CloneSO")]
    [SerializeField] private PlayerCloneScriptableObject normalCloneSO;
    [SerializeField] private PlayerCloneScriptableObject advanceCloneSO;

    [Header("Max Clone Allow")]
    [SerializeField] private int maxNumberOfNormalClone;
    [SerializeField] private int maxNumberOfAdvanceClone;

    private GameObject[] normalCloneArray = new GameObject[10];
    private GameObject[] advanceCloneArray = new GameObject[5];
    private int currentNumberOfNormalClone;
    private int currentNumberOfAdvanceClone;
    private int currentNumberOfClone;
    // private int checkPointId;


    private void Start()
    {

    }

    void Update()
    {
        currentNumberOfNormalClone = GameObject.FindObjectsOfType<NormalClone>().Length;
        currentNumberOfAdvanceClone = GameObject.FindObjectsOfType<AdvanceClone>().Length;
        currentNumberOfClone = currentNumberOfNormalClone + currentNumberOfAdvanceClone*10;
        
        GameManager.Instance.currentNumberOfNormalClone = currentNumberOfNormalClone;
        GameManager.Instance.currentNumberOfAdvanceClone = currentNumberOfAdvanceClone;
        GameManager.Instance.currentNumberOfClone = currentNumberOfClone;
        
    }

    public void SpawnCloneHandler()
    {
        // GameManager.Instance.InvokeOnNormalCloneSpawn();
        currentNumberOfNormalClone = GameManager.Instance.currentNumberOfNormalClone;
        currentNumberOfAdvanceClone = GameManager.Instance.currentNumberOfAdvanceClone;
        currentNumberOfClone = GameManager.Instance.currentNumberOfClone;

        int numberNormalCloneSpawn = 0;

        // checkPointId = GameManager.Instance.checkPointId;
        int math = GameManager.Instance.math;
        int equationResult = GameManager.Instance.equationResult;
        int newNumberOfClone = NewNumberOfClone(math, equationResult, currentNumberOfClone);



        print("CurrentNumberOfClone: " + currentNumberOfClone);
        print("equationResult"+equationResult);


        //Destroy all Clone
        DestroyClone(normalCloneArray, maxNumberOfNormalClone, StringList.NORMAL_CLONE);
        DestroyClone(advanceCloneArray, maxNumberOfAdvanceClone, StringList.ADVANCE_CLONE);
        
        
        for (int i = 0; i < newNumberOfClone; i++)
        {       
            SpawnNormalClone();
            numberNormalCloneSpawn++;
            if(numberNormalCloneSpawn == maxNumberOfNormalClone) 
            {
                SpawnAdvanceClone();
                numberNormalCloneSpawn = 0;
            }
        }
        
    }

    public void SpawnNormalClone()
    {   
        SpawnClone(normalCloneSO.playerClonePrefab);
    }

    public void SpawnAdvanceClone()
    {        
        DestroyClone(normalCloneArray, maxNumberOfNormalClone, StringList.NORMAL_CLONE);
        SpawnClone(advanceCloneSO.playerClonePrefab);    
        
    }



    private void DestroyClone(GameObject[] cloneArray, 
    int maxNumberTypeOfClone, string cloneName)
    {
        cloneArray = GameObject.FindGameObjectsWithTag(cloneName);
        for (int i = 0; i < cloneArray.Length; i++)
        {
            Destroy(cloneArray[i]);
        }
    }

    private void SpawnClone(GameObject clonePrefab)
    {                
        Vector3 position = new Vector3(Random.Range(-3, 3), 0.51f, Random.Range(-3, 3));

        Instantiate(clonePrefab, position, Quaternion.identity);

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
