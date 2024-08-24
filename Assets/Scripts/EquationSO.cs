using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EquationSO", menuName = "ScriptableObjects/EquationSO")]
public class EquationSO : ScriptableObject
{
    public enum Math
    {
        Add, 
        Sub,
        Mul,
        Div,
        Equal
    }

    [System.Serializable]
    public struct Equation
    {
        public string equationName;
        public int equationResult;
        public Math math;
    }

    public Equation[] equations;

}
