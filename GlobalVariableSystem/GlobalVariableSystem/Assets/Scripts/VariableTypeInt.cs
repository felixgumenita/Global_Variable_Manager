using System.Collections.Generic;
using GlobalVariable;
using System;

[Serializable]
public class VariableTypeInt : VariableBase
{
    public int IntValue;

    public VariableTypeInt(string name, string description, int value, GlobalVariableManager.VariableType type, List<VariableBase> list)
    {
        VariableName = name;
        VariableDescription = description;
        IntValue = value;
        VariableType = (int)type;

        SetID(list);

    }
}
