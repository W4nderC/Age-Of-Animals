using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CheckPoint : MonoBehaviour
{
    private string checkPointName;
    [SerializeField] private EquationTextUI equationTextUI;
    
    private void Start()
    {
        checkPointName = gameObject.name;


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
            GameManager.Instance.InvokeOnSecondCheckPointTouched();
        }

        if (other.gameObject.name == StringList.PLAYER)
        {
            ReturnCheckPointId();

            GameManager.Instance.math = equationTextUI.math;
            GameManager.Instance.equationResult = equationTextUI.equationResult;
            GameManager.Instance.InvokeOnAnyCheckPointTouched();

            
        }
    }

    private void ReturnCheckPointId()
    {
        if(checkPointName == StringList.FIR_CHECKPOINT_LEFT)
        {
            GameManager.Instance.checkPointId = 1;
        } 
        else if(checkPointName == StringList.FIR_CHECKPOINT_RIGHT)
        {
            GameManager.Instance.checkPointId = 2;
        } 
        else if(checkPointName == StringList.SEC_CHECKPOINT_LEFT)
        {
            GameManager.Instance.checkPointId = 3;
        } 
        else if(checkPointName == StringList.SEC_CHECKPOINT_RIGHT)
        {
            GameManager.Instance.checkPointId = 4;
        }    
    }

    private void OnTriggerExit(Collider other)
    {
        GameManager.Instance.IsCheckPointTouched = false;
    }
}
