using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set;}

    [HideInInspector] public int score;
    [HideInInspector] public int highScore;

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

    void Start()
    {
        if (PlayerPrefs.HasKey(StringList.HIGH_SCORE))
        {
            highScore = PlayerPrefs.GetInt(StringList.HIGH_SCORE);
        }

        if (GameManager.Instance.OnGameOver == null)
            GameManager.Instance.OnGameOver = new UnityEvent();
        GameManager.Instance.OnGameOver.AddListener(ScoreUpdate);
    }

    private void ScoreUpdate()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt(StringList.HIGH_SCORE, highScore);
        }
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnGameOver.RemoveListener(ScoreUpdate);
    }
}
