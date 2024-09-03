using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPath : MonoBehaviour
{
    private Vector3 currentPos;
    private float zValue;

    [SerializeField] private float moveSpd;
    // [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject movingPathPrefab;
    [SerializeField] private GameObject spawnMovingPathPos;

    [SerializeField] private int stateBreakNum = 10;
    [SerializeField] private int stateAccumulateNum = 100;

    private void Start()
    {
        GameManager.Instance.OnSecondCheckPointTouched += GameManager_OnSecondCheckPointTouched;
        int currentNumberOfClone = DataManager.Instance.currentNumberOfClone;
        ChangeSpawnState(currentNumberOfClone);  
    }

    private void GameManager_OnSecondCheckPointTouched(object sender, EventArgs e)
    {
        SpawnMovingPath();
    }

    private void Update()
    {   
        if(GameManager.Instance.IsGameState(GameManager.GameState.GamePlaying)) 
        {
            zValue = transform.position.z;
            if (zValue > -40f)
            {
                // rb.velocity = Vector3.back * moveSpd;
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, 0, -60), moveSpd * Time.deltaTime);
            } else
            {
                Destroy(gameObject);
            }   
        }
        else if (GameManager.Instance.IsGameState(GameManager.GameState.GameOver))
        {
            // rb.velocity = Vector3.zero;
            transform.position = Vector3.zero;
        }
    }

    private void SpawnMovingPath()
    {
        Instantiate(movingPathPrefab, spawnMovingPathPos.transform.position, Quaternion.identity);
        //print("Spawn");
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnSecondCheckPointTouched -= GameManager_OnSecondCheckPointTouched;
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
