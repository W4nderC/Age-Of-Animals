using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private SoundSO audioClipRefsSO;
 
    private void Start()
    {
        EnemyFromBehind.OnAnyExplosion += EnemyFromBehind_OnAnyExplosion;
        CheckPoint.OnAnyCheckPointTouched += CheckPoint_OnAnyCheckPointTouched;
        EnemySound.OnAnySelfDestruct += IEnemySelfDestructable_OnAnySelfDestruct;
    }

    private void IEnemySelfDestructable_OnAnySelfDestruct(object sender, System.EventArgs e)
    {
        EnemySound enemySound = sender as EnemySound;
        PlaySound(audioClipRefsSO.explode, enemySound.transform.position);
        print("sound location "+enemySound.transform.position);
    }

    private void CheckPoint_OnAnyCheckPointTouched(object sender, System.EventArgs e)
    {
        CheckPoint checkPoint = sender as CheckPoint;
        PlaySound(audioClipRefsSO.checkPointTouched, checkPoint.transform.position);
    }

    private void EnemyFromBehind_OnAnyExplosion(object sender, System.EventArgs e)
    {
        EnemyFromBehind enemyFromBehind = sender as EnemyFromBehind;
        PlaySound(audioClipRefsSO.explode, enemyFromBehind.transform.position); 
    }

    public void PlaySound (AudioClip[] audioClipArray, Vector3 pos, float volume = 1f) {
        PlaySound (audioClipArray[Random.Range(0, audioClipArray.Length)], pos, volume);
    }

    public void PlaySound (AudioClip audioClip, Vector3 pos, float volume = 1f) {
        AudioSource.PlayClipAtPoint (audioClip, pos, volume);
    }

    private void OnDestroy() {
        EnemyFromBehind.OnAnyExplosion -= EnemyFromBehind_OnAnyExplosion;
        CheckPoint.OnAnyCheckPointTouched -= CheckPoint_OnAnyCheckPointTouched;
    }
}
