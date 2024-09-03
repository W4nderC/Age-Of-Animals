using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class CheckPoint : MonoBehaviour
{
    
    [SerializeField] private EquationTextUI equationTextUI;
    [SerializeField] private GameObject obstacle;
    
    private BoxCollider col;
    private string checkPointName;
    
    private void Start()
    {
        checkPointName = gameObject.name;

        col = GetComponent<BoxCollider>();

        if (GameManager.Instance.OnAnyCheckPointTouched == null)
            GameManager.Instance.OnAnyCheckPointTouched = new UnityEvent();

        GameManager.Instance.OnAnyCheckPointTouched.AddListener(DisableCheckPoint);
    }

    private void Update()
    {

    }

    private void OnEnable()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if ((checkPointName == StringList.SEC_CHECKPOINT_LEFT 
        || checkPointName == StringList.SEC_CHECKPOINT_RIGHT) 
            && other.gameObject.name == StringList.PLAYER) 
        {
            //Spawn MovingPath
            
        }

        if (other.gameObject.name == StringList.PLAYER)
        {
            GameManager.Instance.InvokeOnSecondCheckPointTouched();
            // ReturnCheckPointId();

            DataManager.Instance.math = equationTextUI.math;
            DataManager.Instance.equationResult = equationTextUI.equationResult;
            GameManager.Instance.InvokeOnAnyCheckPointTouched();
            print("Check");
            obstacle.GetComponent<Obstacle>().Show();
        }
    }

    public void DisableCheckPoint()
    {
        col.enabled = false;
    }

    private void OnDestroy() 
    {
        GameManager.Instance.OnAnyCheckPointTouched.RemoveListener(DisableCheckPoint);
    }
}
