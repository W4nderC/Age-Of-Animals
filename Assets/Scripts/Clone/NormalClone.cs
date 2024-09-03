using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalClone : MonoBehaviour, IPlayerClone
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckNumberOfTypeClone()
    {

    }

    public void SelfDestroy()
    {
        Destroy(gameObject);
    }
}
