using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GamePausedUI : MonoBehaviour
{
    [SerializeField] private Button returnButton;
    [SerializeField] private Button resumeButton;

    private void Awake() 
    {
        returnButton.onClick.AddListener(() => 
        {
            Loader.Load(Loader.Scene.MainMenuScene);
        });  
        resumeButton.onClick.AddListener(() =>
        {
            GameManager.Instance.TogglePauseGame();
            GameManager.Instance.GameStateChange(GameManager.GameState.GamePlaying);
        });
    }

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance.OnGamePaused == null)
            GameManager.Instance.OnGamePaused = new UnityEvent();

        if (GameManager.Instance.OnGameUnpaused == null)
            GameManager.Instance.OnGameUnpaused = new UnityEvent();

        GameManager.Instance.OnGamePaused.AddListener(Show);  
        GameManager.Instance.OnGameUnpaused.AddListener(Hide);
        Hide();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Show()
    {
        gameObject.SetActive(true);
        resumeButton.Select();
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void OnDestroy() 
    {
        GameManager.Instance.OnGamePaused.RemoveListener(Show);  

        GameManager.Instance.OnGameUnpaused.RemoveListener(Hide);
    }
}
