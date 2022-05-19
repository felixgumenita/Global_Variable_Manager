using System.Collections.Generic;
using GlobalVariable;
using UnityEngine;
using System;

[Serializable]
public class VariableTypeVector : VariableBase
{
    public float X;
    public float Y;
    public float Z;

    public VariableTypeVector(string name, string description, Vector3 vector, GlobalVariableManager.VariableType type, List<VariableBase> list)
    {
        VariableName = name;
        VariableDescription = description;
        X = vector.x;
        Y = vector.y;
        Z = vector.z;
        VariableType = (int)type;

        SetID(list);
    }
}
