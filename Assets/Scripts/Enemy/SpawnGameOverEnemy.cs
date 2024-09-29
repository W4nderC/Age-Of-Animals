using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGameOverEnemy : MonoBehaviour, IEnemySelfDestructable
{
    [SerializeField] private EnemySound enemySound;

    private Rigidbody rb;

    [SerializeField] private float fallMutiplier = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.down.normalized, ForceMode.Impulse);
    }


    private void FixedUpdate() 
    {
        if(rb.velocity.y < 0f) 
        {
            rb.velocity += Physics.gravity * fallMutiplier * Time.deltaTime;

        } 

    }

    public void SelfDestruction()
    {
        enemySound.InvokeOnAnySelfDestruct();
        Destroy(gameObject);  
    }
}
