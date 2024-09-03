using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWaitingToStartUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnWaitingToStart += GameManager_OnWaitingToStart;
    }

    private void GameManager_OnWaitingToStart(object sender, EventArgs e)
    {
        Show();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) 
        {
            GameManager.Instance.GameStateChange(GameManager.GameState.GamePlaying);
            Hide();
        }
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
