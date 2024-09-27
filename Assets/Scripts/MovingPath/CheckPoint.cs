using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class CheckPoint : MonoBehaviour
{
    public static event EventHandler OnAnyCheckPointTouched;
    
    [SerializeField] private EquationTextUI equationTextUI;
    [SerializeField] private GameObject obstacle;
    
    [SerializeField] private BoxCollider leftCol;
    [SerializeField] private BoxCollider rightCol;

    
    private void Start()
    {

        // if (GameManager.Instance.OnAnyCheckPointTouched == null)
        //     GameManager.Instance.OnAnyCheckPointTouched = new UnityEvent();

        // GameManager.Instance.OnAnyCheckPointTouched.AddListener(DisableCheckPoint);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == StringList.PLAYER)
        {
            OnAnyCheckPointTouched?.Invoke(this, EventArgs.Empty); // play sound
            DataManager.Instance.math = equationTextUI.math;
            DataManager.Instance.equationResult = equationTextUI.equationResult;
            GameManager.Instance.InvokeOnAnyCheckPointTouched();
            obstacle.GetComponent<Obstacle>().Show();
            DisableCheckPoint();
        }
    }

    public void DisableCheckPoint()
    {
        leftCol.enabled = false;
        rightCol.enabled = false;
    }

    // private void OnDestroy() 
    // {
    //     GameManager.Instance.OnAnyCheckPointTouched.RemoveListener(DisableCheckPoint);
    // }
}
