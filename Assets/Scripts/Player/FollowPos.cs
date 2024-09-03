using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPos : MonoBehaviour
{
    public GameObject[] followPosArray;
    private GameObject[] normalCloneArray;
    private GameObject[] advanceCloneArray;
    private GameObject[] hardCloneArray;
    private GameObject[] subCloneArray;
    private GameObject[] bossCloneArray;

    [SerializeField] private float spd;

    private void Update()
    {
        normalCloneArray = GameObject.FindGameObjectsWithTag(StringList.NORMAL_CLONE);
        advanceCloneArray = GameObject.FindGameObjectsWithTag(StringList.ADVANCE_CLONE);
        hardCloneArray = GameObject.FindGameObjectsWithTag(StringList.HARD_CLONE);
        subCloneArray = GameObject.FindGameObjectsWithTag(StringList.SUB_CLONE);
        bossCloneArray = GameObject.FindGameObjectsWithTag(StringList.BOSS_CLONE);


        for (int x = 0; x < followPosArray.Length; x++)
        {
            // Boss clone
            for (int i = 0; i < bossCloneArray.Length; i++)
            {
                // bossCloneArray[i].GetComponent<FollowPlayer>().followTarget = followPosArray[i];
                bossCloneArray[i].transform.position = Vector3.MoveTowards
                (
                    bossCloneArray[i].transform.position, 
                    followPosArray[i].transform.position, 
                    spd*Time.deltaTime
                );
            }

            // Sub clone
            for (int i = 0; i < subCloneArray.Length; i++)
            {
                // subCloneArray[i].GetComponent<FollowPlayer>().followTarget = followPosArray[i + bossCloneArray.Length];
                subCloneArray[i].transform.position = Vector3.MoveTowards
                (
                    subCloneArray[i].transform.position, 
                    followPosArray
                    [
                        i + bossCloneArray.Length
                    ].transform.position, 
                    spd*Time.deltaTime
                );
            }

            // Hard clone
            for (int i = 0; i < hardCloneArray.Length; i++)
            {
                // hardCloneArray[i].GetComponent<FollowPlayer>().followTarget = followPosArray[i + subCloneArray.Length 
                // + bossCloneArray.Length];
                hardCloneArray[i].transform.position = Vector3.MoveTowards
                (
                    hardCloneArray[i].transform.position, 
                    followPosArray
                    [
                        i + subCloneArray.Length 
                        + bossCloneArray.Length
                    ].transform.position, 
                    spd*Time.deltaTime
                );
            }

            // Advance clone
            for (int i = 0; i < advanceCloneArray.Length; i++)
            {
                // advanceCloneArray[i].GetComponent<FollowPlayer>().followTarget = followPosArray[i + hardCloneArray.Length 
                // + subCloneArray.Length + bossCloneArray.Length];
                advanceCloneArray[i].transform.position = Vector3.MoveTowards
                (
                    advanceCloneArray[i].transform.position, 
                    followPosArray
                    [
                        i + hardCloneArray.Length 
                        + subCloneArray.Length 
                        + bossCloneArray.Length
                    ].transform.position, 
                    spd*Time.deltaTime
                );
            }

            // Normal clone
            for (int i = 0; i < normalCloneArray.Length; i++)
            {
                // normalCloneArray[i].GetComponent<FollowPlayer>().followTarget = followPosArray[i + advanceCloneArray.Length 
                // + hardCloneArray.Length + subCloneArray.Length + bossCloneArray.Length];
                normalCloneArray[i].transform.position = Vector3.MoveTowards
                (
                    normalCloneArray[i].transform.position, 
                    followPosArray
                    [
                        i + advanceCloneArray.Length 
                        + hardCloneArray.Length 
                        + subCloneArray.Length 
                        + bossCloneArray.Length
                    ].transform.position, 
                    spd*Time.deltaTime
                );
            }
        }       


    }
}
