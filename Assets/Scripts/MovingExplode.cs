using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingExplode : MonoBehaviour
{
    private float zValue;
    [SerializeField] private float moveSpd = 10;

    void Start()
    {
        
    }

    void Update()
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
}
