using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFromBehind : MonoBehaviour
{
    [SerializeField] private GameObject explodePrefab;
    [SerializeField] private float spd;

    void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if(gameObject.transform.position.z < 30f) 
        {
            transform.position = Vector3.MoveTowards
            (
                transform.position, 
                new Vector3(transform.position.x, transform.position.y, transform.position.z + 10f), 
                spd*Time.deltaTime
            );
        } else {
            Destroy(gameObject);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == StringList.PLAYER)
        {
            Destroy(gameObject);
            Instantiate(explodePrefab);
        }

    }
    
}
