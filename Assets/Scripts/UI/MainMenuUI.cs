using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private PlaySoundEffect playSoundEffect;   
    [SerializeField] private Button playBtn;
    [SerializeField] private Button quitBtn;   

    private void Awake() 
    {
        playBtn.onClick.AddListener(() => {
            playSoundEffect.InvokeOnAnyBtnPressed();
            Loader.Load(Loader.Scene.PlayingScene);
        });  
        quitBtn.onClick.AddListener(() => {
            playSoundEffect.InvokeOnAnyBtnPressed();
            Application.Quit();
        });  

        Time.timeScale = 1f;
    }    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
