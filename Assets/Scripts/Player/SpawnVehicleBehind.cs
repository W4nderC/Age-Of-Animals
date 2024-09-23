using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnVehicleBehind : MonoBehaviour
{
    [SerializeField] GameObject[] vehiclePrefabArray;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnVehicleFromBehindPlayer()
    {   

        for(int i = 0; i < vehiclePrefabArray.Length; i++) {
            Instantiate(vehiclePrefabArray[i], 
            new Vector3(Random.Range(-3, 3), 0.001f, -9), Quaternion.identity);
        }
    }

}
