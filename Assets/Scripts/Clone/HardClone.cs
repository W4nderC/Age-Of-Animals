using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HardClone : MonoBehaviour
{
    private void Start() {
        if (GameManager.Instance.OnGameOver == null)
            GameManager.Instance.OnGameOver = new UnityEvent();

        GameManager.Instance.OnGameOver.AddListener(SelfDestroy);
    }

    private void OnDestroy() {
        GameManager.Instance.OnGameOver.RemoveListener(SelfDestroy);
    }

    private void SelfDestroy()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision other)
    {
        IEnemySelfDestructable enemySelfDestructable = other.gameObject.GetComponent<IEnemySelfDestructable>();
        if (enemySelfDestructable != null)
        {
            enemySelfDestructable.SelfDestruction();
        }

    }
}
