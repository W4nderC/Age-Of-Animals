using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public event EventHandler OnSecondCheckPointTouched;

    public UnityEvent OnAnyCheckPointTouched;
    //Spawn Clone event
    public UnityEvent OnNormalCloneSpawn;
    public UnityEvent OnAdvanceCloneSpawn;

    public bool IsCheckPointTouched;
    public int checkPointId; 
    // SpawnPlayer
    public int currentNumberOfNormalClone;
    public int currentNumberOfAdvanceClone;
    public int currentNumberOfClone;
    // CheckPoint
    public int math;
    public int equationResult;
    
    public enum GameState
    {
        GameWaitingToStart,
        GamePlaying,
        GamePaused,
        GameOver
    }

    public GameState gameState;

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
    }

    private void Update()
    {
        GameStateHandler();
        
    }

    private void GameStateHandler()
    {
        switch (gameState)
        {
            case GameState.GameWaitingToStart:
                break;
            case GameState.GamePlaying:
                break;
            case GameState.GamePaused:
                break;
            case GameState.GameOver:
                break;
        }
    }

    public void InvokeOnSecondCheckPointTouched() 
    {
        OnSecondCheckPointTouched?.Invoke(this, EventArgs.Empty);
    }

    public void InvokeOnAnyCheckPointTouched()
    {
        OnAnyCheckPointTouched?.Invoke();
        IsCheckPointTouched = true;
    }
    public void InvokeOnNormalCloneSpawn()
    {
        OnNormalCloneSpawn?.Invoke();
    }    
    
    public void InvokeOnAdvanceCloneSpawn()
    {
        OnAdvanceCloneSpawn?.Invoke();
    }

}
