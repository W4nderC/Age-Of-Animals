using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringList : MonoBehaviour
{
    public static StringList Instance { get; private set; }
    // GameObject clone tag
    public const string PLAYER = "Player";
    public const string NORMAL_CLONE = "NormalClone";
    public const string ADVANCE_CLONE = "AdvanceClone";
    public const string HARD_CLONE = "HardClone";
    public const string SUB_CLONE = "SubClone";
    public const string BOSS_CLONE = "BossClone";

    // GameObject Enemy tag
    public const string NORMAL_ENEMY = "NormalEnemy";
    public const string ADVANCE_ENEMY = "AdvanceEnemy";
    public const string HARD_ENEMY = "HardEnemy";
    public const string SUB_ENEMY = "SubEnemy";
    public const string BOSS_ENEMY = "BossEnemy";
    
    // GameObject CheckPoint name
    public const string SEC_CHECKPOINT_LEFT = "SecondCheckPointLeft";
    public const string SEC_CHECKPOINT_RIGHT = "SecondCheckPointRight";
    public const string FIR_CHECKPOINT_LEFT = "FirstCheckPointLeft";
    public const string FIR_CHECKPOINT_RIGHT = "FirstCheckPointRight";

    // GameState name
    // public const string GAME_WAITING_TO_START = "GameWaitingToStart";
    // public const string GAME_PLAYING = "GamePlaying";
    // public const string GAME_PAUSED = "GamePaused";
    // public const string GAME_OVER = "GameOver";

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
}
