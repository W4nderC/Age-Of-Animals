using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using System;


public class SpawnGameOverObject : MonoBehaviour
{
    [SerializeField] private GameObject[] gameOverObjectArray;
    [SerializeField] private Transform playerGameObject; 
    [SerializeField] private int spawnNumber; 

    private void Start() 
    {
        GameManager.Instance.OnSpawnGameOverEnemy += GameManager_OnSpawnGameOverEnemy;
    }

    private void GameManager_OnSpawnGameOverEnemy(object sender, EventArgs e)
    {
        SpawnObject();
    }

    public void SpawnObject () 
    {   for (int i = 0; i < spawnNumber; i++)
        {
            Vector3 pos = new Vector3
            (
                playerGameObject.position.x + UnityEngine.Random.Range(-1, 1),
                playerGameObject.position.y,
                playerGameObject.position.z + UnityEngine.Random.Range(-1, 1)
            );
            Instantiate(gameOverObjectArray[UnityEngine.Random.Range(0, gameOverObjectArray.Length)], pos, UnityEngine.Random.rotation);
        }
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnSpawnGameOverEnemy -= GameManager_OnSpawnGameOverEnemy;
    }
}
