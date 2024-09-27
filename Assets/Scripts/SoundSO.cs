using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundSO", menuName = "ScriptableObjects/SoundSO")]
public class SoundSO : ScriptableObject
{
    public AudioClip[] checkPointTouched;
    public AudioClip[] explode;
}
