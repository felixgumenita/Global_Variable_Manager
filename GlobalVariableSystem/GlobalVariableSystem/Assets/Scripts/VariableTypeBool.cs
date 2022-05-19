using System.Collections.Generic;
using GlobalVariable;
using System;

[Serializable]
public class VariableTypeBool : VariableBase
{
    public bool BoolValue;

    public VariableTypeBool(string name, string description, bool value, GlobalVariableManager.VariableType type, List<VariableBase> list)
    {
        VariableName = name;
        VariableDescription = description;
        BoolValue = value;
        VariableType = (int)type;

        SetID(list);

    }
}
