using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace GlobalVariable
{
    public class ManagerController : MonoBehaviour
    {
        public GlobalVariableManager globalVariableManager;
        private void Awake()
        {
            if(globalVariableManager == null)
            {
                var manager = Resources.Load<GlobalVariableManager>("Managers/GlobalVariablaManager");
                globalVariableManager = manager;
                print(manager);
            }
        }
    }
}