using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float remainingTime;
    [SerializeField] private Image circleImage;

    private float setTimer;
    // private float elapsedTime;

    void Start()
    {
        setTimer = remainingTime;
    }

    // Update is called once per frame
    void Update()
    {
        // elapsedTime += Time.deltaTime;
        // int minutes = Mathf.FloorToInt(elapsedTime / 60);
        // int seconds = Mathf.FloorToInt(elapsedTime % 60);
        // timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    
        if (GameManager.Instance.IsGameState(GameManager.GameState.GamePlaying))
        {
            CountDownTimer();
        }
    }

    private void CountDownTimer () {

        if(remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        } 
        else if(remainingTime <= 0) 
        {
            remainingTime = 0;
            GameManager.Instance.GameStateChange(GameManager.GameState.GameOver);
        }
        
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    
        circleImage.fillAmount = remainingTime / setTimer;
    }
}
