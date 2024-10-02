using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameWaitingToStartUI : MonoBehaviour
{
    [SerializeField] private Button playBtn;

    private void Awake() {
        playBtn.onClick.AddListener(() => 
        {
            GameManager.Instance.InvokeOnGamePlayingEvent();
            Hide();
        });
    }

    void Start()
    {
        GameManager.Instance.OnWaitingToStart += GameManager_OnWaitingToStart;
    }

    private void GameManager_OnWaitingToStart(object sender, EventArgs e)
    {
        Show();
    }


    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnWaitingToStart -= GameManager_OnWaitingToStart;
    }
}
