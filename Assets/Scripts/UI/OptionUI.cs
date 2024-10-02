using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class OptionUI : MonoBehaviour
{
    [SerializeField] private Button pausedBtn;

    // Start is called before the first frame update
    void Awake()
    {
        pausedBtn.onClick.AddListener(() => 
        {
            PlayerMovementControl.Instance.OnPausedAction?.Invoke();
        });
    }

    private void Start() 
    {
        if (GameManager.Instance.OnGameOver == null)
            GameManager.Instance.OnGameOver = new UnityEvent();
        GameManager.Instance.OnGameOver.AddListener(Hide);

        Show();
    }

    private void Hide(){
        gameObject.SetActive(false); 
    }

    private void Show(){
        gameObject.SetActive(true); 
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnGameOver.RemoveListener(Hide);
    }
}
