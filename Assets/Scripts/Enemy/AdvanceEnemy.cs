using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AdvanceEnemy : MonoBehaviour, IEnemySelfDestructable
{
    [SerializeField] private EnemySound enemySound;
    [SerializeField] private float moveSpd;
    [SerializeField] private float fallMutiplier = 20f;
    [SerializeField] private GameObject explodePrefab; 

    private float zValue;
    private Rigidbody rb;
    private bool selfDestroy;
    
    private void Start() 
    {
        GameManager.Instance.OnObstaclesDestroy += GameManager_OnObstaclesDestroy;
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.down.normalized, ForceMode.Impulse);
    }
    
    private void GameManager_OnObstaclesDestroy(object sender, EventArgs e)
    {
        selfDestroy = true;
    }

    private void FixedUpdate()
    {
        // add gravity while in the air
        if(rb.velocity.y < 0f) 
        {
            rb.velocity += Physics.gravity * fallMutiplier * Time.deltaTime;

        } 

        zValue = transform.position.z;
        if (zValue > -40f)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, 0, -60), moveSpd * Time.deltaTime);
        } else
        {
            Destroy(gameObject);
        } 
    }

    private void OnDestroy() {
        GameManager.Instance.OnObstaclesDestroy -= GameManager_OnObstaclesDestroy;
    }

    public void SelfDestruction()
    {
        if(selfDestroy) {
            Instantiate(explodePrefab, transform.position, Quaternion.identity);
            enemySound.InvokeOnAnySelfDestruct();
            Destroy(gameObject);  
        }
    }
}
