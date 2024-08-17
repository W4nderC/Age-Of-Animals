using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPath : MonoBehaviour
{
    private Vector3 currentPos;
    private float zValue;

    [SerializeField] private float moveSpd;
    [SerializeField] private Rigidbody rb;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        zValue = transform.position.z;
        if (zValue > 0)
        {
            rb.velocity = Vector3.back * moveSpd * Time.deltaTime;
        }
        
    }
}
