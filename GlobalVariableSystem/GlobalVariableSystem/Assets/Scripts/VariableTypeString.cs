using System.Collections.Generic;
using GlobalVariable;
using System;

[Serializable]
public class VariableTypeString : VariableBase
{
    public string StringValue;

    public VariableTypeString(string name, string description, string value, GlobalVariableManager.VariableType type, List<VariableBase> list)
    {
        VariableName = name;
        VariableDescription = description;
        StringValue = value;
        VariableType = (int)type;

        SetID(list);

    }
}
