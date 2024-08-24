using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneSpawnPos : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;

    public bool IsThisPosOccupy()
    {
        return Physics.CheckBox(transform.position, new Vector3(.5f, .5f, .5f), 
            Quaternion.identity, layerMask);

    }
}
