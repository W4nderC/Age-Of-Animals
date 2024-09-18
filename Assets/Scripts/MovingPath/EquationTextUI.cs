using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EquationTextUI : MonoBehaviour
{
    [SerializeField] private TextMeshPro textMeshPros;
    [SerializeField] private EquationSO equationSO;

    [HideInInspector] public int equationResult;
    [HideInInspector] public int math;

    private void Start()
    {   

        int i = Random.Range(0, EquationControl());
        textMeshPros.text = equationSO.equations[i].equationName;
        equationResult = equationSO.equations[i].equationResult;
        math = (int)equationSO.equations[i].math;
    }

    private int EquationControl () 
    {
        int tempNum = 0;
        if (GameManager.Instance.IsSpawnState(GameManager.SpawnState.Break))
        {
            tempNum = 5;
        } 
        else if(GameManager.Instance.IsSpawnState(GameManager.SpawnState.Accumulate))
        {
            tempNum = 20;
        }
        else if(GameManager.Instance.IsSpawnState(GameManager.SpawnState.Peak))
        {
            tempNum = equationSO.equations.Length;
        }

        return tempNum;
    }


}
