using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPath : MonoBehaviour
{
    private Vector3 currentPos;
    private float zValue;

    [SerializeField] private float moveSpd;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject movingPathPrefab;
    [SerializeField] private GameObject spawnMovingPathPos;


    private void Start()
    {
        GameManager.Instance.OnSecondCheckPointTouched += GameManager_OnSecondCheckPointTouched;

    }

    private void Update()
    {

    }

    private void GameManager_OnSecondCheckPointTouched(object sender, EventArgs e)
    {
        SpawnMovingPath();
    }

    private void FixedUpdate()
    {
        zValue = transform.position.z;
        if (zValue > -40f)
        {
            rb.velocity = Vector3.back * moveSpd;
        } else
        {
            Destroy(gameObject);
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

    
}
