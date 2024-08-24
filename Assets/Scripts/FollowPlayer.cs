using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private GameObject followTarget;
    private Vector3 randomPos;
    [SerializeField] private float spd;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        followTarget = GameObject.FindGameObjectWithTag(StringList.PLAYER);
    }

    // Update is called once per frame
    private void Update()
    {
        randomPos = new Vector3(followTarget.transform.position.x + Random.Range(-2,2), 
            followTarget.transform.position.y,
            followTarget.transform.position.z + Random.Range(-2, 2));
        transform.position = Vector3.MoveTowards(transform.position, 
            randomPos, spd*Time.deltaTime);
    }
}
