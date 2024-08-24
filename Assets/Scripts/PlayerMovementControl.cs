using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementControl : MonoBehaviour
{
    private PlayerControls playerControls;
    //private bool isWalking;

    [SerializeField] private float moveSpd;

    private void Awake()
    {
        playerControls = new PlayerControls();
        playerControls.PLayer.Enable();
    }
    void Start()
    {
        

    }

    // Update is called once per frame
    private void Update()
    {
        Vector2 inputVector = GetInputVectorNormalized();

        Vector3 moveDir = new Vector3(inputVector.x, 0, 0);
        transform.position += moveDir * Time.deltaTime * moveSpd;

       //isWalking = moveDir != Vector3.zero;
    }

    private Vector2 GetInputVectorNormalized()
    {
        Vector2 inputVector = playerControls.PLayer.Move.ReadValue<Vector2>();
        inputVector = inputVector.normalized;

        return inputVector;

    }
}
