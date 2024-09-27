using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameFinishedUI : MonoBehaviour
{
    [SerializeField] private Button returnButton;

    private void Awake() {
        returnButton.onClick.AddListener(() => {
            Loader.Load(Loader.Scene.MainMenuScene);
        });
    }

    void Start()
    {
        GameManager.Instance.OnGameFinish += GameManager_OnGameFinish;
        Hide();
    }

    private void GameManager_OnGameFinish(object sender, EventArgs e)
    {
        Show();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void OnDestroy() {
        GameManager.Instance.OnGameFinish -= GameManager_OnGameFinish;
    }
}
