using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EquationTextUI : MonoBehaviour
{
    [SerializeField] private TextMeshPro textMeshPros;
    [SerializeField] private EquationSO equationSO;

    public int equationResult;
    public int math;

    private void OnEnable()
    {
        int i = Random.Range(0, equationSO.equations.Length);
        textMeshPros.text = equationSO.equations[i].equationName;
        equationResult = equationSO.equations[i].equationResult;
        math = (int)equationSO.equations[i].math;
    }
}
