using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubClone : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        IEnemySelfDestructable enemySelfDestructable = other.gameObject.GetComponent<IEnemySelfDestructable>();
        if (enemySelfDestructable != null)
        {
            enemySelfDestructable.SelfDestruction();
        }

    }
}
