using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVC : MonoBehaviour
{
    [SerializeField] private GameObject smokeVisual;
    [SerializeField] private Animator animator;

    private void Start() 
    {
        smokeVisual.SetActive(false);
        GameManager.Instance.OnGamePlaying += GameManager_OnGamePlaying;
        animator.SetBool("IsGamePlaying", false);
    }

    private void GameManager_OnGamePlaying(object sender, EventArgs e)
    {
        smokeVisual.SetActive(true);
        animator.SetBool("IsGamePlaying", true);
    }
}
