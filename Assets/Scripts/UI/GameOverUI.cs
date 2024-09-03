using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private Button returnBtn;
    private void Awake() 
    {
        returnBtn.onClick.AddListener(() => 
        {
            Loader.Load(Loader.Scene.MainMenuScene);
        });
    }
    
    void Start()
    {
        if (GameManager.Instance.OnGameOver == null)
            GameManager.Instance.OnGameOver = new UnityEvent();

        GameManager.Instance.OnGameOver.AddListener(EnableGameOverUI);
        Hide();
        
    }

    private void EnableGameOverUI()
    {
        // if(GameManager.Instance.IsGameOver()
        if(GameManager.Instance.IsGameState(GameManager.GameState.GameOver)) 
        {
            Show();
        } else 
        {
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
        GameManager.Instance.OnGameOver.RemoveListener(EnableGameOverUI);
    }
}
