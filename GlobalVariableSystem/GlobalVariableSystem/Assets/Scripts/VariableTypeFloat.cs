using System.Collections.Generic;
using GlobalVariable;
using System;

[Serializable]
public class VariableTypeFloat : VariableBase
{
    public float FloatValue;

    public VariableTypeFloat(string name, string description, float value, GlobalVariableManager.VariableType type, List<VariableBase> list)
    {
        VariableName = name;
        VariableDescription = description;
        FloatValue = value;
        VariableType = (int)type;

        SetID(list);
    }
}
