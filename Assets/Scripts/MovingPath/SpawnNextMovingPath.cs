using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnNextMovingPath : MonoBehaviour
{
    [SerializeField] private GameObject movingPathPrefab;
    [SerializeField] private Transform spawnMovingPathPos;
    [SerializeField] private BoxCollider col;
    [SerializeField] private SpawnNextMovingPath spawnNextMovingPath;

    void Start()
    {
        // GameManager.Instance.OnSpawnNewPath += GameManager_InvokeOnSpawnNewPath;
    }

    // private void GameManager_InvokeOnSpawnNewPath(object sender, EventArgs e)
    // {
    //     SpawnMovingPath();
        
    // }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name == StringList.PLAYER) 
        {
            // GameManager.Instance.InvokeOnSpawnNewPath();
            SpawnMovingPath();
            col.enabled = false;
            spawnNextMovingPath.enabled = false;
        }
    }

    private void SpawnMovingPath()
    {
        Instantiate(movingPathPrefab, spawnMovingPathPos.position, Quaternion.identity);
    }

    // private void OnDestroy()
    // {
    //     GameManager.Instance.OnSpawnNewPath -= GameManager_InvokeOnSpawnNewPath;
    // }
}
