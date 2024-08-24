using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerCloneSO", menuName = "ScriptableObjects/PlayerCloneSO")]
public class PlayerCloneScriptableObject : ScriptableObject
{
    public GameObject playerClonePrefab;
    public int playerClonePoint;
}
