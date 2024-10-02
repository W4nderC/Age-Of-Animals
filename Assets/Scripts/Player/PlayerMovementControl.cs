using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerMovementControl : MonoBehaviour
{
    public static PlayerMovementControl Instance { get; private set; }

    public UnityEvent OnPausedAction;

    private PlayerControls playerControls;
    //private bool isWalking;

    [SerializeField] private float moveSpd;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        } 
        else
        {
            Instance = this;
        }

        playerControls = new PlayerControls();
        playerControls.PLayer.Enable();

        playerControls.PLayer.Paused.performed += Paused_performed;
    }

    private void Paused_performed(InputAction.CallbackContext context)
    {
        OnPausedAction?.Invoke();
    }

    private void Update()
    {
        if (GameManager.Instance.IsGameState(GameManager.GameState.GamePlaying))
        {
            Vector2 inputVector = GetInputVectorNormalized();

            Vector3 moveDir = new Vector3(inputVector.x, 0, 0);
            transform.position += moveDir * Time.deltaTime * moveSpd;
        }
    }

    private Vector2 GetInputVectorNormalized()
    {
        Vector2 inputVector = playerControls.PLayer.Move.ReadValue<Vector2>();
        inputVector = inputVector.normalized;

        return inputVector;
    }

    private void OnDestroy() 
    {
        playerControls.PLayer.Paused.performed -= Paused_performed;
        playerControls.Dispose();
    }

    void OnCollisionEnter(Collision other)
    {
        IEnemySelfDestructable enemySelfDestructable = other.gameObject.GetComponent<IEnemySelfDestructable>();
        if (enemySelfDestructable != null)
        {
            enemySelfDestructable.SelfDestruction();
        }

    }
}
