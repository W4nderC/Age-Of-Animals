using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyFromBehind : MonoBehaviour
{
    public static event EventHandler OnAnyExplosion;
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
        for (int i = 0; i < GameManager.Instance.friendlyUnitList.Count; i++)
        {
            if(other.gameObject.tag == GameManager.Instance.friendlyUnitList[i]) {
                Instantiate(explodePrefab, transform.position, Quaternion.identity);
                OnAnyExplosion?.Invoke(this, new EventArgs());
                Destroy(gameObject);
            }
        }

    }
    
}
