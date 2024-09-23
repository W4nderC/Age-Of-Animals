using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPath : MonoBehaviour
{
    private float zValue;

    [SerializeField] private float moveSpd;

    [SerializeField] private int stateBreakNum = 10;
    [SerializeField] private int stateAccumulateNum = 100;


    private void Start()
    {
        int currentNumberOfClone = DataManager.Instance.newNumberOfClone;
        // int currentNumberOfClone = DataManager.Instance.CurrentNumOfClone();

        ChangeSpawnState(currentNumberOfClone);  

    }

    private void Update()
    {   
        if(GameManager.Instance.IsGameState(GameManager.GameState.GamePlaying)) 
        {
            zValue = transform.position.z;
            if (zValue > -33f)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, 0, -60), moveSpd * Time.deltaTime);
            } else
            {
                Destroy(gameObject);
            }   
        }
        else if (GameManager.Instance.IsGameState(GameManager.GameState.GameOver))
        {
            transform.position = Vector3.zero;
        }
    }

    private void ChangeSpawnState(int currentNumberOfClone)
    {
        if(currentNumberOfClone <= stateBreakNum) 
        {
            GameManager.Instance.SpawnStateChange(GameManager.SpawnState.Break);
        }
        else if (currentNumberOfClone > stateBreakNum
        && currentNumberOfClone <= stateAccumulateNum)
        {
            GameManager.Instance.SpawnStateChange(GameManager.SpawnState.Accumulate);
        }
        else if (currentNumberOfClone > stateAccumulateNum)
        {
            GameManager.Instance.SpawnStateChange(GameManager.SpawnState.Peak);
        }
    }    
}
