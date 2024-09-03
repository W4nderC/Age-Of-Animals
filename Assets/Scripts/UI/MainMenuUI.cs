using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button playBtn;
    [SerializeField] private Button quitBtn;   

    private void Awake() 
    {
        playBtn.onClick.AddListener(() => {
            print("Play");
            Loader.Load(Loader.Scene.PlayingScene);
        });  
        quitBtn.onClick.AddListener(() => {
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
