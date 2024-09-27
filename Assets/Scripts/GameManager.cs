using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    // Event when player touched checkpoint
    public event EventHandler OnSpawnNewPath;
    // Destroy all enemy
    public event EventHandler OnObstaclesDestroy;
    // Event waiting to start
    public event EventHandler OnWaitingToStart;
    // Spawn GameOver Enemy
    public event EventHandler OnSpawnGameOverEnemy;
    // Game finished event
    public event EventHandler OnGameFinish;
    public UnityEvent OnAnyCheckPointTouched;
    // Spawn Clone event
    public UnityEvent OnNormalCloneSpawn;
    public UnityEvent OnAdvanceCloneSpawn;
    // Game State change event
    public UnityEvent OnGameOver;
    // Toggle pause menu
    public UnityEvent OnGamePaused;
    public UnityEvent OnGameUnpaused;
 
    [HideInInspector] public List<String> friendlyUnitList = new List<string>()
    {
        StringList.PLAYER,
        StringList.NORMAL_CLONE,
        StringList.ADVANCE_CLONE,
        StringList.HARD_CLONE,
        StringList.SUB_CLONE,
        StringList.BOSS_CLONE,
    };

    [HideInInspector] public List<String> unfriendlyUnitList = new List<string>()
    {
        StringList.NORMAL_ENEMY,
        StringList.ADVANCE_ENEMY,
        StringList.HARD_ENEMY,
        StringList.SUB_ENEMY,
        StringList.BOSS_ENEMY,
    };

    private bool isGamePaused = false;
    
    public enum GameState
    {
        GameWaitingToStart,
        GamePlaying,
        GamePaused,
        GameOver,
        GameFinished
    }

    public enum SpawnState
    {
        Break,
        Accumulate,
        Peak,
    }

    public GameState gameState;
    public SpawnState spawnState;

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

    private void Start() 
    {
        if (PlayerMovementControl.Instance.OnPausedAction == null)
            PlayerMovementControl.Instance.OnPausedAction = new UnityEvent();

        PlayerMovementControl.Instance.OnPausedAction.AddListener(TogglePauseGame); 
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
                OnWaitingToStart?.Invoke(this, EventArgs.Empty);
                break;
            case GameState.GamePlaying:
                SpawnStateHandler();

                break;
            case GameState.GamePaused:
                break;
            case GameState.GameOver:

                break;
            case GameState.GameFinished:
                OnGameFinish?.Invoke(this, EventArgs.Empty);
                break;
        }
    }

    private void SpawnStateHandler()
    {
        switch(spawnState)
        {
            case SpawnState.Break:
                break;
            case SpawnState.Accumulate:
                break;
            case SpawnState.Peak:
                break;
        }
    }

    public void InvokeOnSpawnNewPath() 
    {
        OnSpawnNewPath?.Invoke(this, EventArgs.Empty);
    }

    public void InvokeOnAnyCheckPointTouched()
    {
        OnAnyCheckPointTouched?.Invoke();
    }
    public void InvokeOnNormalCloneSpawn()
    {
        OnNormalCloneSpawn?.Invoke();
    }    
    
    public void InvokeOnAdvanceCloneSpawn()
    {
        OnAdvanceCloneSpawn?.Invoke();
    }

    public void GameStateChange (GameState stateName) 
    {
        if(stateName == GameState.GameWaitingToStart) 
        {
            gameState = GameState.GameWaitingToStart;
        }        
        else if(stateName == GameState.GamePlaying) 
        {
            gameState = GameState.GamePlaying;
        }        
        else if(stateName == GameState.GamePaused) 
        {
            gameState = GameState.GamePaused;
        }        
        else if(stateName == GameState.GameOver) 
        {
            gameState = GameState.GameOver;
        }
        else
        {
            gameState = GameState.GameFinished;
        }
    }

    public void SpawnStateChange (SpawnState stateName) 
    {
        if(stateName == SpawnState.Break) 
        {
            spawnState = SpawnState.Break;
        }        
        else if(stateName == SpawnState.Accumulate) 
        {
            spawnState = SpawnState.Accumulate;
        }        
        else if(stateName == SpawnState.Peak) 
        {
            spawnState = SpawnState.Peak;
        }        
    }

    public bool IsGameState(GameState stateName)
    {
        return gameState == stateName;        
    }

    public bool IsSpawnState(SpawnState spawnStateName)
    {
        return spawnState == spawnStateName;
    }

    public void TogglePauseGame(){
        isGamePaused = !isGamePaused;
        if(isGamePaused) {
            Time.timeScale = 0f; //Pause the game

            OnGamePaused?.Invoke();
        } else {
            Time.timeScale = 1f; //Unpause

            OnGameUnpaused?.Invoke();
        }
    }

    private void OnDestroy()
    {
        PlayerMovementControl.Instance.OnPausedAction.RemoveListener(TogglePauseGame); 
    }

    public void InvokeOnObstaclesDestroy () 
    {
        OnObstaclesDestroy?.Invoke(this, EventArgs.Empty);
    }

    public void InvokeOnSpawnGameOverEnemy () {
        OnSpawnGameOverEnemy?.Invoke(this, EventArgs.Empty);
    }

    public void CheckWinCondition () 
    {
        if(DataManager.Instance.newNumberOfClone >= 500) {
            GameStateChange(GameState.GameFinished);
        }
    }

}
