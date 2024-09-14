using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class CheckPoint : MonoBehaviour
{
    
    [SerializeField] private EquationTextUI equationTextUI;
    [SerializeField] private GameObject obstacle;
    
    [SerializeField] private BoxCollider col;

    private string checkPointName;
    
    private void Start()
    {
        checkPointName = gameObject.name;

        // if (GameManager.Instance.OnAnyCheckPointTouched == null)
        //     GameManager.Instance.OnAnyCheckPointTouched = new UnityEvent();

        // GameManager.Instance.OnAnyCheckPointTouched.AddListener(DisableCheckPoint);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == StringList.PLAYER)
        {
            DataManager.Instance.math = equationTextUI.math;
            DataManager.Instance.equationResult = equationTextUI.equationResult;
            GameManager.Instance.InvokeOnAnyCheckPointTouched();
            obstacle.GetComponent<Obstacle>().Show();
            DisableCheckPoint();
        }
    }

    public void DisableCheckPoint()
    {
        col.enabled = false;
    }

    // private void OnDestroy() 
    // {
    //     GameManager.Instance.OnAnyCheckPointTouched.RemoveListener(DisableCheckPoint);
    // }
}
