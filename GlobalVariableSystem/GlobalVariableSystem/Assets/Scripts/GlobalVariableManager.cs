using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace GlobalVariable
{
    [CreateAssetMenu(fileName = "GlobalVariableManager", menuName = "Managers/Global Variable Manager", order = 1)]
    public class GlobalVariableManager: ScriptableObject
    {
        public string VariableNameLabel = "Name";
        public string VariableDescriptionLabel = "Variable Description";
        public int SelectedContent = 0;

        public enum VariableType { Bool, Integior, Float, String, Vector }
        public VariableType variableType = VariableType.Bool;

        [SerializeReference]
        public List<VariableBase> Variables = new List<VariableBase>();


        #region Public Get Functions
        public bool GetBooleanValue(int varID)
        {
            foreach(VariableBase v in Variables)
            {
                if (v.VariableID == varID)
                {
                    if(v.VariableType == 0)
                    {
                        var varBool = v as VariableTypeBool;
                        Debug.Log($"{v.VariableName} is {varBool.BoolValue}");
                        return varBool.BoolValue;
                    }
                    else
                    {
                        Debug.LogError($"{v.VariableName} [id: {v.VariableID}] is not a boolean.\nThe Default value return false.");
                        return false;
                    }

                }
            }

            Debug.LogError($"There is no a variable with id: {varID}.\nThe value return false.");
            return false;

        }
        public int GetIntegiorValue(int varID)
        {
            foreach (VariableBase v in Variables)
            {
                if (v.VariableID == varID)
                {
                    if (v.VariableType == 1)
                    {
                        var varInt = v as VariableTypeInt;
                        Debug.Log($"{v.VariableName} is {varInt.IntValue}");
                        return varInt.IntValue;
                    }
                    else
                    {
                        Debug.LogError($"{v.VariableName} [id: {v.VariableID}] is not a Integior.\nThe Default value return 0.");
                        return 0;
                    }

                }
            }

            Debug.LogError($"There is no a variable with id: {varID}.\nThe value return 0.");
            return 0;
        }
        public float GetFloatValue(int varID)
        {
            foreach (VariableBase v in Variables)
            {
                if (v.VariableID == varID)
                {
                    if (v.VariableType == 2)
                    {
                        var varFloat = v as VariableTypeFloat;
                        Debug.Log($"{v.VariableName} is {varFloat.FloatValue}");
                        return varFloat.FloatValue;
                    }
                    else
                    {
                        Debug.LogError($"{v.VariableName} [id: {v.VariableID}] is not a Float.\nThe Default value return 0.");
                        return 0;
                    }

                }
            }

            Debug.LogError($"There is no a variable with id: {varID}.\nThe value return 0.");
            return 0;
        }
        public string GetStringValue(int varID)
        {
            foreach (VariableBase v in Variables)
            {
                if (v.VariableID == varID)
                {
                    if (v.VariableType == 3)
                    {
                        var varString = v as VariableTypeString;
                        Debug.Log($"{v.VariableName} is {varString.StringValue}");
                        return varString.StringValue;
                    }
                    else
                    {
                        Debug.LogError($"{v.VariableName} [id: {v.VariableID}] is not a String.\nThe Default value return Empty.");
                        return string.Empty;
                    }

                }
            }

            Debug.LogError($"There is no a variable with id: {varID}.\nThe value return Empty.");
            return string.Empty;
        }
        public Vector3 GetVectorVale(int varID)
        {
            foreach (VariableBase v in Variables)
            {
                if (v.VariableID == varID)
                {
                    if (v.VariableType == 4)
                    {
                        var varVector = v as VariableTypeVector;
                        var x = varVector.X;
                        var y = varVector.Y;
                        var z = varVector.Z;

                        Debug.Log($"{v.VariableName} is Vector3({x},{y},{z})");

                        return new Vector3(x,y,z);
                    }
                    else
                    {
                        Debug.LogError($"{v.VariableName} [id: {v.VariableID}] is not a Vector.\nThe Default value return Vector3(0,0,0).");
                        return Vector3.zero;
                    }

                }
            }

            Debug.LogError($"There is no a variable with id: {varID}.\nThe value return Vector3(0,0,0).");
            return Vector3.zero;
        }
        #endregion

        #region Public Set Functions
        public void SetBooleanValue(int varID, bool value)
        {
            foreach (VariableBase v in Variables)
            {
                if (v.VariableID == varID)
                {
                    if (v.VariableType == 0)
                    {
                        var varBool = v as VariableTypeBool;

                        varBool.BoolValue = value;

                        Debug.Log($"{varBool.VariableName} is {varBool.BoolValue}");
                        return;
                    }
                    else
                    {
                        Debug.LogError($"{v.VariableName} [id: {v.VariableID}] is not a Boolen.");
                        return;
                    }

                }
            }

            Debug.LogError($"There is no a variable with id: {varID}.");
            return;
        }
        public void SetIntegiourValue(int varID, int value)
        {
            foreach (VariableBase v in Variables)
            {
                if (v.VariableID == varID)
                {
                    if (v.VariableType == 1)
                    {
                        var varInt = v as VariableTypeInt;

                        varInt.IntValue = value;

                        Debug.Log($"{varInt.VariableName} is {varInt.IntValue}");
                        return;
                    }
                    else
                    {
                        Debug.LogError($"{v.VariableName} [id: {v.VariableID}] is not a Integior.");
                        return;
                    }

                }
            }

            Debug.LogError($"There is no a variable with id: {varID}.");
            return;
        }
        public void SetFloatValue(int varID, float value)
        {
            foreach (VariableBase v in Variables)
            {
                if (v.VariableID == varID)
                {
                    if (v.VariableType == 2)
                    {
                        var varFloat = v as VariableTypeFloat;

                        varFloat.FloatValue = value;

                        Debug.Log($"{varFloat.VariableName} is {varFloat.FloatValue}");
                        return;
                    }
                    else
                    {
                        Debug.LogError($"{v.VariableName} [id: {v.VariableID}] is not a Float.");
                        return;
                    }

                }
            }

            Debug.LogError($"There is no a variable with id: {varID}.");
            return;
        }
        public void SetStringValue(int varID, string value)
        {
            foreach (VariableBase v in Variables)
            {
                if (v.VariableID == varID)
                {
                    if (v.VariableType == 3)
                    {
                        var varString = v as VariableTypeString;

                        varString.StringValue = value;

                        Debug.Log($"{varString.VariableName} is {varString.StringValue}");
                        return;
                    }
                    else
                    {
                        Debug.LogError($"{v.VariableName} [id: {v.VariableID}] is not a String.");
                        return;
                    }

                }
            }

            Debug.LogError($"There is no a variable with id: {varID}.");
            return;
        }
        public void SetVectorValue(int varID, Vector3 value)
        {
            foreach (VariableBase v in Variables)
            {
                if (v.VariableID == varID)
                {
                    if (v.VariableType == 4)
                    {
                        var varVector = v as VariableTypeVector;
                        varVector.X = value.x;
                        varVector.Y = value.y;
                        varVector.Z = value.z;

                        Debug.Log($"{varVector.VariableName} is Vector3({varVector.X},{varVector.Y},{varVector.Z})");

                        return;
                    }
                    else
                    {
                        Debug.LogError($"{v.VariableName} [id: {v.VariableID}] is not a Vector.");
                        return;
                    }

                }
            }

            Debug.LogError($"There is no a variable with id: {varID}.");
            return;
        }
        #endregion

        #region Public Function Editor
        public void CreateVariable(VariableType variableType)
        {
            switch (variableType)
            {
                case VariableType.Bool:

                    var boolVar = new VariableTypeBool
                        (VariableNameLabel, VariableDescriptionLabel, false, variableType, Variables);

                    Variables.Add(boolVar);

                    break;

                case VariableType.Float:

                    var floatVar = new VariableTypeFloat
                        (VariableNameLabel, VariableDescriptionLabel, 0, variableType, Variables);

                    Variables.Add(floatVar);

                    break;

                case VariableType.Integior:

                    var integiorVar = new VariableTypeInt
                        (VariableNameLabel, VariableDescriptionLabel, 0, variableType, Variables);

                    Variables.Add(integiorVar);

                    break;

                case VariableType.String:

                    var stringVar = new VariableTypeString
                        (VariableNameLabel, VariableDescriptionLabel, " ", variableType, Variables);

                    Variables.Add(stringVar);

                    break;

                case VariableType.Vector:

                    var vectorVar = new VariableTypeVector
                        (VariableNameLabel, VariableDescriptionLabel, new Vector3(0, 0, 0), variableType, Variables);

                    Variables.Add(vectorVar);

                    break;
            }
        }
        #endregion

        #region Private Function

        #endregion

    }
}

