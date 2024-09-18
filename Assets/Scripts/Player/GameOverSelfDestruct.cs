using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverSelfDestruct : MonoBehaviour
{
    [SerializeField] private GameObject explodePrefab;

    private bool selfDestruct;

    private void Start() {
        selfDestruct = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        for (int i = 0; i < GameManager.Instance.unfriendlyUnitList.Count; i++)
        {
            if(other.gameObject.tag == GameManager.Instance.unfriendlyUnitList[i]) 
            {
                selfDestruct = true;
            }
        }
        if (GameManager.Instance.IsGameState(GameManager.GameState.GameOver)
        && selfDestruct)
        {
            Instantiate(explodePrefab, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
            GameManager.Instance.OnGameOver?.Invoke();
        }
    }
}
