using System.Collections.Generic;
using GlobalVariable;
using System;

[Serializable]
public class VariableBase
{
    public string VariableName;
    public string VariableDescription;
    public int VariableType;
    public int VariableID;


    public void SetID(List<VariableBase> list)
    {
        int id = 0;

        List<int> ids = new List<int>();

        foreach (VariableBase v in list) ids.Add(v.VariableID);

        if (ids == null)
        {
            VariableID = id;
            return;
        }
        else
        {
            while (ids.Contains(id))
            {
                id++;
            }

            VariableID = id;
        }

    }

}
