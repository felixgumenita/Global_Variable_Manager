using UnityEngine;
using GlobalVariable;

public class GetSetTester : MonoBehaviour
{
    public enum State { Get, Set}
    public State state = State.Get;
    public enum Type { Bool, Integior, Float, String, Vector };
    public Type type = Type.Bool;

    [SerializeField] int VarID = 0;

    [Header("If State = Set")]
    [SerializeField] bool boolValue;
    [SerializeField] int intValue;
    [SerializeField] float floatValue;
    [SerializeField] string stringValue;
    [SerializeField] Vector3 vectorValue;

    GlobalVariableManager varManager;
    
    private void Awake()
    {
        var controller = FindObjectOfType<ManagerController>();

        varManager = controller.globalVariableManager;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) CheckType(state, type);
    }

    private void CheckType(State _state, Type _type)
    {
        switch (_state)
        {
            case State.Get:
                if (_type == Type.Bool) varManager.GetBooleanValue(VarID);
                else if (_type == Type.Integior) varManager.GetIntegiorValue(VarID);
                else if (_type == Type.Float) varManager.GetFloatValue(VarID);
                else if (_type == Type.String) varManager.GetStringValue(VarID);
                else if (_type == Type.Vector) varManager.GetVectorVale(VarID);
                break;
            
            case State.Set:
                if (_type == Type.Bool) varManager.SetBooleanValue(VarID,boolValue);
                else if (_type == Type.Integior) varManager.SetIntegiourValue(VarID,intValue);
                else if (_type == Type.Float) varManager.SetFloatValue(VarID,floatValue);
                else if (_type == Type.String) varManager.SetStringValue(VarID,stringValue);
                else if (_type == Type.Vector) varManager.SetVectorValue(VarID,vectorValue);
                break;
        }
    }
}
